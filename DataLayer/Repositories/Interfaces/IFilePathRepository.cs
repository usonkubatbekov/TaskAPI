using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface IFilePathRepository
    {
        FilesPath GetFilesPathById (int filepathid);

        List<FilesPath> GetAllFilePath();

        List<FilesPath> GetAllFilesPathByTaskId(int taskId);

        FilesPath CreateFilePath(FilesPath filesPath);

        void UpdateFilePath(string filePath);

        void DeleteFilePath(FilesPath filesPath);
    }
}
