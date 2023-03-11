using AutoMapper;
using DataLayer.Entities;
using ServiceLayer.Dtos;
using ServiceLayer.Manager.Interface;
using ServiceLayer.Service.Interface;

namespace ServiceLayer.Service
{
    public class FilePathService : IFilePathService
    {
        private readonly IDataManager _dataManager;

        private readonly IMapper _mapper;

        public FilePathService(IDataManager dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        public FilePathDto GetFilePathById(int filePathDtoId)
        {
            return _mapper.Map<FilePathDto>(_dataManager.FilePathRepo.GetFilesPathById(filePathDtoId));
        }

        public List<FilePathDto> GetAllFilePath()
        {
            return _mapper.Map<List<FilePathDto>>(_dataManager.FilePathRepo.GetAllFilePath());
        }

        public List<string> GetFilePathByTaskId(int taskId) 
        {
            List<string> result = new List<string>();

            var listFilepathfromDb = _mapper.Map<List<FilePathDto>>(_dataManager.FilePathRepo.GetAllFilesPathByTaskId(taskId));
            
            foreach (var filepath in listFilepathfromDb)
            {
                var intermediateResult = filepath.FilePath;
                result.Add(intermediateResult);
            }

            return result;
        }
        
        public List<FilePathDto> GetFilePathsByTaskId(int taskId)
        {
            return _mapper.Map<List<FilePathDto>>(_dataManager.FilePathRepo.GetAllFilesPathByTaskId(taskId));
        }

        public FilePathDto SaveFilePath(FilePathDto filePathDto)
        {
            FilesPath filesPath = new FilesPath();

            filesPath.FilePath = filePathDto.FilePath;
            filesPath.TaskId = filePathDto.TaskId;

            var createFilesPath = _dataManager.FilePathRepo.CreateFilePath(filesPath);

            return _mapper.Map<FilePathDto>(createFilesPath);

        }

        public void UpdateFilePath(string filePath)
        {
            _dataManager.FilePathRepo.UpdateFilePath(filePath);
        }

        public FilePathDto DeleteFilePath(FilePathDto filePathDto)
        {
            var filePathEntitiis = _mapper.Map<FilesPath>(filePathDto);
            _dataManager.FilePathRepo.DeleteFilePath(filePathEntitiis);
            return filePathDto;
        }

    }
}
