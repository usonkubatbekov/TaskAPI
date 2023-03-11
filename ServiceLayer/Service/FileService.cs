using AutoMapper;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using ServiceLayer.Dtos;
using ServiceLayer.Manager.Interface;
using ServiceLayer.Service.Interface;

namespace ServiceLayer.Service
{
    /// <summary>
    /// File service
    /// </summary>
    public class FileService : IFileService
    {
        private readonly IFilePathService _filePathService;
        private readonly IDataManager _dataManager;
        private readonly IMapper _mapper;

        public FileService(IFilePathService filePathService, IDataManager dataManager, IMapper mapper)
        {
            _filePathService = filePathService;
            _dataManager = dataManager;
            _mapper = mapper;
        }

        /// <summary>
        /// File uploads
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> FileUploads(IFormFile formFile)
        {
            string filename;
            try
            {
                var extension = "." + formFile.FileName.Split('.')[formFile.FileName.Split('.').Length - 1];
                filename = Guid.NewGuid() + extension;

                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);
                await using var stream = new FileStream(exactpath, FileMode.Create);
                await formFile.CopyToAsync(stream);
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }

            return filename;
        }

        /// <summary>
        /// Update task files
        /// </summary>
        /// <param name="taskDto"> Task DTO </param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateTaskFiles(TaskDtofromPost taskDto)
        {
            var newFiles = taskDto.TaskFiles.ToDictionary(file => file.FileName);

            if (taskDto.TaskFiles is null || !taskDto.TaskFiles.Any())
                throw new Exception("Task can not be Null!");
            
            var existingFiles = _filePathService.GetFilePathsByTaskId(taskDto.Id);
            
            // Файлы на добавление
            var addedFiles = newFiles
                .Where(file => existingFiles.All(existingFile => existingFile.FilePath != file.Key))
                .ToDictionary(file => file.Key, file => file.Value);
            await AddFiles(addedFiles, taskDto.Id);
            
            // Файлы на обновление
            var updatedFiles = existingFiles.Where(file => newFiles.ContainsKey(file.FilePath!)).ToList();
            await UpdateFiles(updatedFiles, newFiles);
            
            // Файлы на удаление
            var deletedFiles = existingFiles.Where(file => !newFiles.ContainsKey(file.FilePath!)).ToList();
            DeleteFiles(deletedFiles);
        }

        /// <summary>
        /// Добавление файлов
        /// </summary>
        /// <param name="addedFiles"></param>
        /// <param name="taskId"></param>
        private async Task AddFiles(Dictionary<string, IFormFile> addedFiles, int taskId)
        {
            foreach (var file in addedFiles)
            {
                var fileName = $"{Guid.NewGuid()}_{file.Key}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);

                await using var stream = new FileStream(filePath, FileMode.Create);
                await file.Value.CopyToAsync(stream);

                var data = new FilesPath
                {
                    FilePath = filePath,
                    TaskId = taskId,
                };

                _dataManager.FilePathRepo.CreateFilePath(data);
            }
        }

        /// <summary>
        /// Обновление файлов
        /// </summary>
        /// <param name="updatedFiles"></param>
        /// <param name="newFiles"></param>
        private async Task UpdateFiles(List<FilePathDto> updatedFiles, IReadOnlyDictionary<string, IFormFile> newFiles)
        {
            foreach (var file in updatedFiles)
            {
                var newFile = newFiles[file.FilePath!];
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", file.FilePath!);

                await using var stream = new FileStream(filePath, FileMode.Create);
                await newFile.CopyToAsync(stream);
            }
        }
        
        /// <summary>
        /// Удаление файлов
        /// </summary>
        /// <param name="deletedFiles"></param>
        private void DeleteFiles(IEnumerable<FilePathDto> deletedFiles)
        {
            foreach (var filePath in deletedFiles.Select(file => Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", file.FilePath!)).Where(File.Exists))
            {
                File.Delete(filePath);
                _dataManager.FilePathRepo.DeleteFilePath(filePath);
            }
        }
    }

}
