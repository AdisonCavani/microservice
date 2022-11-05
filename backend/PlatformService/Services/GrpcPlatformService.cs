using AutoMapper;
using Grpc.Core;
using PlatformService.Repositories;

namespace PlatformService.Services;

public class GrpcPlatformService : GrpcPlatform.GrpcPlatformBase
{
    private readonly IMapper _mapper;
    private readonly IPlatformRepository _repository;

    public GrpcPlatformService(IMapper mapper, IPlatformRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public override async Task<GetAllPlatformsGrpcResponse> GetAllPlatforms(GetAllPlatformsGrpcRequest req, ServerCallContext ctx)
    {
        var platforms = await _repository.GetAllPlatformsAsync(req.Page);

        if (platforms is null)
            return new GetAllPlatformsGrpcResponse();

        return _mapper.Map<GetAllPlatformsGrpcResponse>(platforms);
    }
}