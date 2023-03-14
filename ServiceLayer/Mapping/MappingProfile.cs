using AutoMapper;
using DataLayer.Entities;
using ServiceLayer.Dtos;

namespace ServiceLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<TaskfromPostDto, DataLayer.Entities.TaskEntity>();
            CreateMap<DataLayer.Entities.TaskEntity, TaskfromPostDto>();

            CreateMap<FilePathDto, FilesPath>();
            CreateMap<FilesPath, FilePathDto>();

            CreateMap<TaskfromGetDto, DataLayer.Entities.TaskEntity>();
            CreateMap<DataLayer.Entities.TaskEntity, TaskfromGetDto>();

        }

    }
}
