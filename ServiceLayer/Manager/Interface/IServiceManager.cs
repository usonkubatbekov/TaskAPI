using ServiceLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Manager.Interface
{
    public interface IServiceManager
    {
        TaskService TaskService { get; }

        FilePathService FilePathService { get; }

        FileUploadService FileUploadService { get; }
    }
}
