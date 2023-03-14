using ServiceLayer.Dtos;

namespace ServiceLayer.Service.Interface
{
    public interface ITaskService
    {
        TaskfromGetDto GetTaskById(int taskId);

        List<TaskfromGetDto> GetAllTasks();

        TaskfromPostDto SaveTask(TaskfromPostDto task);

        Task<TaskfromPostDto> UpdateTask(TaskfromPostDto task);

        public void DeleteTask(int Id);
    }
}
