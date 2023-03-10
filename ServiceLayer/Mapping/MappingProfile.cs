using AutoMapper;
using DataLayer.Entities;
using ServiceLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
