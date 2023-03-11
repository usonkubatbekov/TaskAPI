using ServiceLayer.Dtos;

namespace ServiceLayer.Service.Interface
{
    public interface IFilePathService
    {
        FilePathDto GetFilePathById(int filePathDtoId);
        List<string> GetFilePathByTaskId(int taskId);
        List<FilePathDto> GetFilePathsByTaskId(int taskId);

        List<FilePathDto> GetAllFilePath();

        FilePathDto SaveFilePath(FilePathDto filePathDto);

        void UpdateFilePath(string filePath);

        FilePathDto DeleteFilePath(FilePathDto filePathDto);
    }
}
