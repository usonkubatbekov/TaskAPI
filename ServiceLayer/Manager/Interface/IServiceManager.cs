using ServiceLayer.Service;

namespace ServiceLayer.Manager.Interface
{
    public interface IServiceManager
    {
        TaskService TaskService { get; }

        FilePathService FilePathService { get; }

        FileService FileService { get; }
    }
}
