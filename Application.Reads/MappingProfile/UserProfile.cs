using Application.Reads.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Application.Reads.MappingProfile;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<IdentityUser, IdentityUserDTO>().ReverseMap();
    }
}
