using Application.Reads.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Reads.MappingProfile;

public class PremiumProfile : Profile
{
    public PremiumProfile()
    {
        CreateMap<Premium, PremiumDTO>().ReverseMap();
    }
}