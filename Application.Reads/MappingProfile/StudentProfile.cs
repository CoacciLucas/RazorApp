using Application.Reads.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Reads.MappingProfile;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentDTO>().ReverseMap();
    }
}