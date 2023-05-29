using AutoMapper;
using FIAP_APP.API.Dto.CollegeClass;
using FIAP_APP.API.Dto.Student;
using FIAP_APP.Domain.Models;
using System.Net;

namespace FIAP_APP.API.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<StudentCreationDto, Student>().ReverseMap();
            CreateMap<StudentUpdate, Student>().ReverseMap();
            CreateMap<CollegeClassCreationDto, CollegeClass>().ReverseMap();
            CreateMap<CollegeClassUpdateDto, CollegeClass>().ReverseMap();
        }
    }
}
