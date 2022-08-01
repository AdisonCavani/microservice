using AutoMapper;
using PlatformService.Contracts.Requests;
using PlatformService.Contracts.Responses;
using PlatformService.Database.Entities;
using PlatformService.Domain;

namespace PlatformService.Mappers;

public class PlatformMapper : Profile
{
    public PlatformMapper()
    {
        CreateMap<Platform, GetPlatformResponse>();
        CreateMap<CreatePlatformRequest, Platform>();
        CreateMap<GetAllPlatformsResult, GetAllPlatformsResponse>();
    }
}