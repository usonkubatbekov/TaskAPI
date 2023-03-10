using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using ServiceLayer.Manager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public TaskRepository TaskRepo { get { return (TaskRepository)_taskRepository; } }
        public FilePathRepository FilePathRepo { get { return (FilePathRepository)_filePathRepository; } }
    }
}
