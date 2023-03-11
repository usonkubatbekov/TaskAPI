using DataLayer.Entities;

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

        void DeleteFilePath(string filePath);
    }
}
