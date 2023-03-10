using ServiceLayer.Manager.Interface;
using ServiceLayer.Service;
using ServiceLayer.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Manager 
{
    public class ServiceManager : IServiceManager
    {
        private readonly ITaskService _taskService;

        private readonly IFilePathService _filePathService;

        private readonly IFileUploadService _fileuploadService;
        public ServiceManager(ITaskService taskService, IFilePathService filePathService, IFileUploadService fileuploadService)
        {
            _taskService = taskService;
            _filePathService = filePathService;
            _fileuploadService = fileuploadService;
        }

        public TaskService TaskService { get { return (TaskService) _taskService; } }
        public FilePathService FilePathService { get { return (FilePathService)_filePathService; } }
        public FileUploadService FileUploadService { get { return (FileUploadService)_fileuploadService; } }
    }
}
