using DataLayer.Entities;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dtos;
using ServiceLayer.Manager.Interface;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TasksController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: api/<TasksController>
        [HttpGet("All task")]
        public List<TaskDtofromGet> GetAllTask()
        {
            var tasklist = new List<TaskDtofromGet>();
            var task = _serviceManager.TaskService.GetAllTasks();
            foreach (var taskonly  in task) 
            {
                var filePath = _serviceManager.FilePathService.GetFilePathByTaskId(taskonly.Id);
                taskonly.FilePath = filePath;
                tasklist.Add(taskonly);
            }

            return tasklist;
        }

        // GET api/<TasksController>/5
        [HttpGet("{task by id}")]
        public TaskDtofromGet Get(int Id)
        {
            var task = _serviceManager.TaskService.GetTaskById(Id);
            var filepath = _serviceManager.FilePathService.GetFilePathByTaskId(Id);
            task.FilePath = filepath;
            return task;
        }
        
        [HttpPost]
        [Route("CreateTask")]
        [RequestSizeLimit(10 * 1024)]
        public async Task<IActionResult> CreateTask([FromForm] TaskDtofromPost taskDto)
        {
            if (string.IsNullOrEmpty(Request.GetMultipartBoundary()))
            {
                return BadRequest("Bad post header!");
            }

            if (taskDto.TaskFiles is null) 
                return NotFound("File is not found!");

            var task = _serviceManager.TaskService.SaveTask(taskDto);

            var filePaths = new List<FilePathDto>();

            foreach (var file in taskDto.TaskFiles)
            {
                filePaths.Add(new FilePathDto
                {
                    FilePath = await _serviceManager.FileUploadService.FileUploads(file),
                    TaskId = task.Id,
                    TaskDto = task
                });
            }
            
            var filePathData = filePaths.Select(filePath 
                => _serviceManager.FilePathService.SaveFilePath(filePath)).ToList();

            return Ok(filePathData);

        }

        //// PUT api/<TasksController>/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put([FromForm] TaskDtofromPost taskDto)
        //{
        //    var taskFromDb = _serviceManager.TaskService.GetTaskById(taskDto.Id);
        //    var filePathFromDb = _serviceManager.FilePathService.GetFilePathByTaskId(taskDto.Id);
        //    if (taskDto.Id == taskFromDb.Id)
        //    {
        //        if (taskDto.TaskName != taskFromDb.TaskName)
        //        {
        //            _serviceManager.TaskService.UpdateTask(taskDto);
        //        }
        //        if (taskDto.TaskStatus != taskFromDb.TaskStatus)
        //        {
        //            _serviceManager.TaskService.UpdateTask(taskDto);
        //        }
        //    }
        //    if (taskDto.TaskFiles != null)
        //    {
        //        var filePaths = new List<FilePathDto>();
        //        string FilePathOperation;
        //        foreach (var file in taskDto.TaskFiles)
        //        {
        //            filePaths.Add(new FilePathDto
        //            {
        //                FilePath = await _serviceManager.FileUploadService.FileUploads(file),
        //                TaskId = taskFromDb.Id,
        //            });
        //            foreach (var filePath in filePaths)
        //            {
        //                if (filePath != filePaths)
        //            }
        //        }
        //    }
        //}

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _serviceManager.TaskService.DeleteTask(id);
        }
    }
}
