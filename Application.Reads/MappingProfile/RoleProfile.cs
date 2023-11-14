using Application.Reads.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Application.Reads.MappingProfile;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<IdentityRole, IdentityRoleDTO>().ReverseMap();
    }
}
