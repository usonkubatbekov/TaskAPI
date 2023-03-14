using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using ServiceLayer.Dtos;
using ServiceLayer.Manager.Interface;
using ServiceLayer.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        private readonly IServiceManager _serviceManager;

        public TasksController(IServiceManager serviceManager, IWebHostEnvironment environment)
        {
            _serviceManager = serviceManager;
            _environment = environment;
        }

        /// <summary>
        /// GET: api/<TasksController>
        /// </summary>
        /// <returns></returns>
        [HttpGet("All task")]
        public List<TaskfromGetDto> GetAllTask()
        {
            var tasklist = new List<TaskfromGetDto>();
            var task = _serviceManager.TaskService.GetAllTasks();
            foreach (var taskonly  in task) 
            {
                var filePath = _serviceManager.FilePathService.GetFilePathByTaskId(taskonly.Id);
                taskonly.FilePath = filePath;
                tasklist.Add(taskonly);
            }

            return tasklist;
        }

        /// <summary>
        /// GET api/<TasksController>/5
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{task by id}")]
        public TaskfromGetDto Get(int Id)
        {
            var task = _serviceManager.TaskService.GetTaskById(Id);
            var filepath = _serviceManager.FilePathService.GetFilePathByTaskId(Id);
            task.FilePath = filepath;
            return task;
        }

        [HttpGet]
        [Route("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string filename)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            return File(bytes, contenttype, Path.GetFileName(filepath));
        }

        [HttpPost]
        [Route("CreateTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTask([FromForm] TaskfromPostDto taskDto)
        {
            var webenvironment = _environment.ContentRootPath;
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            if (taskDto.TaskFiles is null) 
                return NotFound("File is not found!");

            var task = _serviceManager.TaskService.SaveTask(taskDto);

            var filePaths = new List<FilePathDto>();

            foreach (var file in taskDto.TaskFiles.Where(file =>file.Length < 10 * 1024))
            {
                filePaths.Add(new FilePathDto
                {
                    FilePath = await _serviceManager.FileService.FileUploadAsync(file, webenvironment),
                    TaskId = task.Id,
                    TaskFromPostDto = task
                });
            }
            
            var filePathData = filePaths.Select(filePath 
                => _serviceManager.FilePathService.SaveFilePath(filePath)).ToList();

            return Ok(filePathData);

        }
        
        [HttpPut("update-task")]
        public async Task<IActionResult> Put([FromForm] TaskfromPostDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            if (taskDto is null)
                throw new Exception("Task can not be null!");

                var task = _serviceManager.TaskService.GetTaskById(taskDto.Id); 
                if (task is null) 
                    throw new Exception("Task not be found!");

             _serviceManager.TaskService.UpdateTask(taskDto);

            await _serviceManager.FileService.UpdateTaskFiles(taskDto);

            return Ok(taskDto);
        }

        /// <summary>
        /// DELETE api/<TasksController>/5
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _serviceManager.TaskService.DeleteTask(id);
        }
    }
}
