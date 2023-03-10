using ServiceLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Interface
{
    public interface IFilePathService
    {
        FilePathDto GetFilePathById(int filePathDtoId);

        List<FilePathDto> GetAllFilePath();

        FilePathDto SaveFilePath(FilePathDto filePathDto);

        FilePathDto UpdateFilePath(FilePathDto filePathDto);

        FilePathDto DeleteFilePath(FilePathDto filePathDto);
    }
}
