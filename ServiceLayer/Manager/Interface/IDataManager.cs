using DataLayer.Repositories;

namespace ServiceLayer.Manager.Interface
{
    public interface IDataManager
    {
        TaskRepository TaskRepo { get; }
        FilePathRepository FilePathRepo { get; }
    }
}
