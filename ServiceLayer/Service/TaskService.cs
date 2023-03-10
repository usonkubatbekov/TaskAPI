using AutoMapper;
using ServiceLayer.Dtos;
using ServiceLayer.Manager.Interface;
using ServiceLayer.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class TaskService : ITaskService
    {
        private readonly IDataManager _dataManager;

        private readonly IMapper _mapper;

        public TaskService(IDataManager dataManager,IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        public TaskDtofromGet GetTaskById(int taskId)
        {
            return _mapper.Map<TaskDtofromGet>(_dataManager.TaskRepo.GetTaskById(taskId));
        }

        public List<TaskDtofromGet> GetAllTasks()
        {
            return _mapper.Map<List<TaskDtofromGet>>(_dataManager.TaskRepo.GetAllTask());
        }

        public TaskDtofromPost SaveTask(TaskDtofromPost taskDto)
        {
            DataLayer.Entities.TaskEntity? taskEntitiis;
            
            if (taskDto.Id !=0)
            {
                taskEntitiis = _dataManager.TaskRepo.GetTaskById(taskDto.Id);
            }
            else 
            {
                taskEntitiis = new DataLayer.Entities.TaskEntity();
            }

            taskEntitiis.TaskName = taskDto.TaskName;
            taskEntitiis.TaskStatus = taskDto.TaskStatus;
            taskEntitiis.DateTimeTask = taskDto.DateTimeTask;

            _dataManager.TaskRepo.CreateTask(taskEntitiis);

            return _mapper.Map<TaskDtofromPost>(taskEntitiis);

        }

        public TaskDtofromPost UpdateTask(TaskDtofromPost taskDto)
        {
            var taskEntitiis = _mapper.Map<DataLayer.Entities.TaskEntity>(taskDto);

            _dataManager.TaskRepo.UpdateTask(taskEntitiis);

            return taskDto;
        }

        public void DeleteTask(int Id)
        {
            _dataManager.TaskRepo.DeleteTask(Id);
        }
    }
}
