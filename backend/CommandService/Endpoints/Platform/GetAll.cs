using Ardalis.ApiEndpoints;
using AutoMapper;
using CommandService.Contracts;
using CommandService.Contracts.Requests;
using CommandService.Contracts.Responses;
using CommandService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CommandService.Endpoints.Platform;

public class GetAll : EndpointBaseAsync
    .WithRequest<GetAllPlatformsRequest>
    .WithActionResult<GetAllPlatformsResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandRepository _repository;

    public GetAll(IMapper mapper, ICommandRepository repository)
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