using AutoMapper;
using ServiceLayer.Dtos;
using ServiceLayer.Manager.Interface;
using ServiceLayer.Service.Interface;

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

        public TaskfromGetDto GetTaskById(int taskId)
        {
            return _mapper.Map<TaskfromGetDto>(_dataManager.TaskRepo.GetTaskById(taskId));
        }

        public List<TaskfromGetDto> GetAllTasks()
        {
            return _mapper.Map<List<TaskfromGetDto>>(_dataManager.TaskRepo.GetAllTask());
        }

        public TaskfromPostDto SaveTask(TaskfromPostDto taskDto)
        {
            DataLayer.Entities.TaskEntity? taskEntities;
            
            if (taskDto.Id !=0)
            {
                taskEntities = _dataManager.TaskRepo.GetTaskById(taskDto.Id);
            }
            else 
            {
                taskEntities = new DataLayer.Entities.TaskEntity();
            }

            if (taskEntities != null)
            {
                taskEntities.TaskName = taskDto.TaskName;
                taskEntities.TaskStatus = taskDto.TaskStatus;
                taskEntities.DateTimeTask = taskDto.DateTimeTask;

                _dataManager.TaskRepo.CreateTask(taskEntities);
            }
            return _mapper.Map<TaskfromPostDto>(taskEntities);
        }

        public async Task<TaskfromPostDto> UpdateTask(TaskfromPostDto taskDto)
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
