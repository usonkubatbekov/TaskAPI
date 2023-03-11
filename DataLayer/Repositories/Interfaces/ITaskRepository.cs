namespace DataLayer.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        List<Entities.TaskEntity> GetAllTask();

        Entities.TaskEntity GetTaskById(int taskid);

        Entities.TaskEntity CreateTask(Entities.TaskEntity taskEntity);

        public void DeleteTask(int id);

        void UpdateTask(Entities.TaskEntity taskEntity);

    }
}
