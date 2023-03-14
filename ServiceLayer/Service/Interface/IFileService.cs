using Microsoft.AspNetCore.Http;
using ServiceLayer.Dtos;

namespace ServiceLayer.Service.Interface
{
    public interface IFileService
    {
        Task<string> FileUploadAsync(IFormFile formFile, string environmentPath);
        Task UpdateTaskFiles(TaskfromPostDto taskDto);
    }
}
