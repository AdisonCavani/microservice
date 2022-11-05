using AutoMapper;
using CommandService.Contracts.Events;
using CommandService.Contracts.Requests;
using CommandService.Contracts.Responses;
using CommandService.Database.Entities;
using CommandService.Domain;
using PlatformService;

namespace CommandService.Mappers;

public class CommandMapper : Profile
{
    public CommandMapper()
    {
        CreateMap<Platform, GetPlatformResponse>();
        CreateMap<CreateCommandRequest, Command>();
        CreateMap<Command, GetCommandForPlatformResponse>();
        CreateMap<GetAllPlatformsResult, GetAllPlatformsResponse>();
        CreateMap<PlatformPublished, Platform>()
            .ForMember(x =>
                x.ExternalId, opt =>
                opt.MapFrom(src => src.Id));
        CreateMap<GrpcPlatformModel, Platform>()
            .ForMember(x =>
                x.ExternalId, opt =>
                opt.MapFrom(src => src.PlatformId))
            .ForMember(x =>
                x.Commands, opt => opt.Ignore());
    }
}