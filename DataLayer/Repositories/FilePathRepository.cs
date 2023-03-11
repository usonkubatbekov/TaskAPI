using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class FilePathRepository : IFilePathRepository
    {
        private readonly TasksDBcontext _dbcontext;

        public FilePathRepository(TasksDBcontext dbcontext)
        {
            this._dbcontext = dbcontext;
        }


        public FilesPath GetFilesPathById(int filepathid)
        {
            return _dbcontext.Files.AsNoTracking().FirstOrDefault(x => x.Id == filepathid);
        }

        public List<FilesPath> GetAllFilePath()
        {
            return _dbcontext.Files.ToList();
        }

        public List<FilesPath> GetAllFilesPathByTaskId(int taskId)
        {
            return _dbcontext.Files.Where(x => x != null && x.TaskId == taskId).ToList();
        }

        public FilesPath CreateFilePath(FilesPath filesPath)
        {
            _dbcontext.Files.Add(filesPath);
            _dbcontext.SaveChanges();
            return filesPath;
        }
        public void UpdateFilePath(string filePath)
        {
            var filePathFromDb = _dbcontext.Files.AsNoTracking().FirstOrDefault(x => x.FilePath == filePath);
            _dbcontext.Files.Update(filePathFromDb);
            _dbcontext.SaveChanges();
        }

        public void DeleteFilePath(FilesPath filesPath)
        {
            _dbcontext.Files.Remove(filesPath);
            _dbcontext.SaveChanges(); ;
        }
        
        public void DeleteFilePath(string filePath)
        {
            var data = _dbcontext.Files.FirstOrDefault(x=>x.FilePath == filePath);

            if (data is null)
            {
                throw new FileNotFoundException($"{filePath} is not find in database");
            }
            
            _dbcontext.Files.Remove(data);
            _dbcontext.SaveChanges(); ;
        }
    }
}
