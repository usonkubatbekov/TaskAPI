using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void DeleteTask(int id)
        {
             var task = GetTaskById(id);
            _dbcontext.Tasks.Remove(task);
            _dbcontext.SaveChanges();
        }
    }
}
