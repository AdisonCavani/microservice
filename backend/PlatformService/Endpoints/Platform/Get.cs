using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Contracts;
using PlatformService.Contracts.Requests;
using PlatformService.Contracts.Responses;
using PlatformService.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace PlatformService.Endpoints.Platform;

public class Get : EndpointBaseAsync
    .WithRequest<GetPlatformRequest>
    .WithActionResult<GetPlatformResponse>
{
    private readonly IMapper _mapper;
    private readonly IPlatformRepository _repository;

    public Get(IMapper mapper, IPlatformRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    [SwaggerOperation(Tags = new[] {"PlatformEndpoint"})]
    [HttpGet(ApiRoutes.Platform.Get)]
    public override async Task<ActionResult<GetPlatformResponse>> HandleAsync(
        [FromQuery] GetPlatformRequest req,
        CancellationToken ct = default)
    {
        var response = await _repository.GetPlatformByIdAsync(req.Id, ct);

        if (response is null)
            return NotFound();

        return Ok(_mapper.Map<GetPlatformResponse>(response));
    }
}