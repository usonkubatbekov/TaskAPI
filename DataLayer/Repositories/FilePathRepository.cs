using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void UpdateFilePath(FilesPath filesPath)
        {
            _dbcontext.Files.Update(filesPath);
            _dbcontext.SaveChanges();
        }

        public void DeleteFilePath(FilesPath filesPath)
        {
            _dbcontext.Files.Remove(filesPath);
            _dbcontext.SaveChanges(); ;
        }
    }
}
