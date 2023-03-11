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
                var extension = "." + formFile.FileName.Split('.')[formFile.FileName.Split('.').Length - 1];
                filename = DateTime.Now.Ticks.ToString() + extension;

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
            catch (Exception ex)
            {
            }
            return filename;
        }

        public void DeleteFiletoDisk(string fileName)
        {
            string ExitingFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);
            System.IO.File.Delete(ExitingFile);
        }

        //{formFile.FileName.GetHashCode()
    }

}
