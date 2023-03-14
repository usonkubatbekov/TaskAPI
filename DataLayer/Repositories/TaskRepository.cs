using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksDBcontext _dbcontext;

        public TaskRepository(TasksDBcontext dbcontext) 
        { 
            this._dbcontext = dbcontext;
        }

        public List<Entities.TaskEntity> GetAllTask()
        {
            return _dbcontext.Tasks.ToList();
        }

        public Entities.TaskEntity? GetTaskById(int taskid)
        {
            return _dbcontext.Tasks!.AsNoTracking<Entities.TaskEntity>().FirstOrDefault(x => x.Id == taskid);
        }

        public Entities.TaskEntity CreateTask(Entities.TaskEntity taskEntity)
        {
            _dbcontext.Tasks.Add(taskEntity);
            _dbcontext.SaveChanges();
            return taskEntity;
        }

        public void UpdateTask(Entities.TaskEntity taskEntity)
        {
            _dbcontext.Tasks.Update(taskEntity);
            _dbcontext.SaveChanges();
        }

        public void DeleteTask(int _id)
        {
             var task = GetTaskById(_id);
            _dbcontext.Tasks.Remove(task);
            _dbcontext.SaveChanges();
        }
    }
}
