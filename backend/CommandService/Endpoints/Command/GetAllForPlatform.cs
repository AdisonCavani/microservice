using Ardalis.ApiEndpoints;
using AutoMapper;
using CommandService.Contracts;
using CommandService.Contracts.Requests;
using CommandService.Contracts.Responses;
using CommandService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CommandService.Endpoints.Command;

public class GetAllForPlatform : EndpointBaseAsync
    .WithRequest<GetAllCommandsRequest>
    .WithActionResult<GetAllCommandsResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandRepository _repository;

    public GetAllForPlatform(IMapper mapper, ICommandRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    [SwaggerOperation(Tags = new[] {"CommandEndpoint"})]
    [HttpGet(ApiRoutes.Command.GetAll)]
    public override async Task<ActionResult<GetAllCommandsResponse>> HandleAsync(
        [FromQuery] GetAllCommandsRequest req,
        CancellationToken ct = default)
    {
        var response = await _repository.GetCommandsForPlatform(req.PlatformId, req.Page, ct);

        if (response is null)
            return NotFound();

        if (!response.Commands.Any())
            return NoContent();

        return _mapper.Map<GetAllCommandsResponse>(response);
    }
}