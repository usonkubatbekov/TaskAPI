using ServiceLayer.Dtos;

namespace ServiceLayer.Service.Interface
{
    public interface ITaskService
    {
        TaskDtofromGet GetTaskById(int taskId);

        List<TaskDtofromGet> GetAllTasks();

        TaskDtofromPost SaveTask(TaskDtofromPost task);

        TaskDtofromPost UpdateTask(TaskDtofromPost task);

        public void DeleteTask(int Id);
    }
}
