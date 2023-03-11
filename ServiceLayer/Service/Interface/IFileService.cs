using Microsoft.AspNetCore.Http;
using ServiceLayer.Dtos;

namespace ServiceLayer.Service.Interface
{
    public interface IFileService
    {
        public Task<string> FileUploads(IFormFile formFile);
        Task UpdateTaskFiles(TaskDtofromPost taskDto);
    }
}
