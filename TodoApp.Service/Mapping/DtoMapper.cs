using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TodoApp.Core.DTOs;
using TodoApp.Core.Model;

namespace TodoApp.Service.Mapping
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<WorkDto, Work>().ReverseMap();
            CreateMap<WorkAddDto, Work>().ReverseMap();
            CreateMap<WorkUpdateDto, Work>().ReverseMap();
            CreateMap<WorkAddDto, WorkClientDto>().ReverseMap();
            CreateMap<WorkClientDto, Work>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
