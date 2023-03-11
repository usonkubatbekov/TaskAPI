using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using ServiceLayer.Manager.Interface;

namespace ServiceLayer.Manager
{
    public class DataManager : IDataManager
    {
        private readonly ITaskRepository _taskRepository;

        private readonly IFilePathRepository _filePathRepository;
        public DataManager(ITaskRepository taskRepository, IFilePathRepository filePathRepository)
        {
            _taskRepository = taskRepository;
            _filePathRepository = filePathRepository;
        }
        public TaskRepository TaskRepo => (TaskRepository)_taskRepository;
        public FilePathRepository FilePathRepo => (FilePathRepository)_filePathRepository;
    }
}
