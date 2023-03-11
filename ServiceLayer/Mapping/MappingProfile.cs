using AutoMapper;
using DataLayer.Entities;
using ServiceLayer.Dtos;

namespace ServiceLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<TaskDtofromPost, DataLayer.Entities.TaskEntity>();
            CreateMap<DataLayer.Entities.TaskEntity, TaskDtofromPost>();

            CreateMap<FilePathDto, FilesPath>();
            CreateMap<FilesPath, FilePathDto>();

            CreateMap<TaskDtofromGet, DataLayer.Entities.TaskEntity>();
            CreateMap<DataLayer.Entities.TaskEntity, TaskDtofromGet>();

        }

    }
}
