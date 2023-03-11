using ServiceLayer.Manager.Interface;
using ServiceLayer.Service;
using ServiceLayer.Service.Interface;

namespace ServiceLayer.Manager 
{
    public class ServiceManager : IServiceManager
    {
        private readonly ITaskService _taskService;

        private readonly IFilePathService _filePathService;

        private readonly IFileService _fileuploadService;
        public ServiceManager(ITaskService taskService, IFilePathService filePathService, IFileService fileuploadService)
        {
            _taskService = taskService;
            _filePathService = filePathService;
            _fileuploadService = fileuploadService;
        }

        public TaskService TaskService { get { return (TaskService) _taskService; } }
        public FilePathService FilePathService { get { return (FilePathService)_filePathService; } }
        public FileService FileService { get { return (FileService)_fileuploadService; } }
    }
}
