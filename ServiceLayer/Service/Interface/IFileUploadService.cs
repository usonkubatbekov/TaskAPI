using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Interface
{
    public interface IFileUploadService
    {
        public Task<string> FileUploads(IFormFile formFile);

    }
}
