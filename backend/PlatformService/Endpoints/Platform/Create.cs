using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Contracts;
using PlatformService.Contracts.Requests;
using PlatformService.Contracts.Responses;
using PlatformService.Repositories;

namespace PlatformService.Endpoints.Platform;

// TODO: CreatedAtRoute ???
public class Create : EndpointBaseAsync
    .WithRequest<CreatePlatformRequest>
    .WithActionResult<CreatePlatformResponse>
{
    private readonly IMapper _mapper;
    private readonly IPlatformRepository _repository;

    public Create(IMapper mapper, IPlatformRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    [HttpPost(ApiRoutes.Platform.Create)]
    public override async Task<ActionResult<CreatePlatformResponse>> HandleAsync(
        CreatePlatformRequest req,
        CancellationToken ct = default)
    {
        var entity = _mapper.Map<Database.Entities.Platform>(req);
        var result = await _repository.CreatePlatformAsync(entity, ct);

        return result
            ? new ObjectResult(new CreatePlatformResponse {Id = entity.Id}) {StatusCode = StatusCodes.Status201Created}
            : StatusCode(StatusCodes.Status500InternalServerError);
    }
}