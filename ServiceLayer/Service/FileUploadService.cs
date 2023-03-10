using Microsoft.AspNetCore.Http;
using ServiceLayer.Service.Interface;

namespace ServiceLayer.Service
{
    public class FileUploadService : IFileUploadService
    {

        public async Task<string> FileUploads(IFormFile formFile)
        {
            string filename = "";

            try
            {
                var extention = "." + formFile.FileName.Split('.')[formFile.FileName.Split('.').Length - 1];

                filename = DateTime.Now.ToString() + extention;

                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            catch
            {

            }
            return filename;
        }
    }
}