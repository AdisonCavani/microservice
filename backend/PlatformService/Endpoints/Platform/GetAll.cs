using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Contracts;
using PlatformService.Contracts.Requests;
using PlatformService.Contracts.Responses;
using PlatformService.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace PlatformService.Endpoints.Platform;

public class GetAll : EndpointBaseAsync
    .WithRequest<GetAllPlatformsRequest>
    .WithActionResult<GetAllPlatformsResponse>
{
    private readonly IMapper _mapper;
    private readonly IPlatformRepository _repository;

    public GetAll(IMapper mapper, IPlatformRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    [SwaggerOperation(Tags = new[] {"PlatformEndpoint"})]
    [HttpGet(ApiRoutes.Platform.GetAll)]
    public override async Task<ActionResult<GetAllPlatformsResponse>> HandleAsync(
        [FromQuery] GetAllPlatformsRequest req,
        CancellationToken ct = default)
    {
        var response = await _repository.GetAllPlatformsAsync(req.Page, ct);

        if (response is null)
            return NotFound();

        if (!response.Platforms.Any())
            return NoContent();

        return Ok(_mapper.Map<GetAllPlatformsResponse>(response));
    }
}