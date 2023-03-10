using ServiceLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
