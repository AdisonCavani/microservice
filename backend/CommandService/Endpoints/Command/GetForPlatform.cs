using Ardalis.ApiEndpoints;
using AutoMapper;
using CommandService.Contracts;
using CommandService.Contracts.Requests;
using CommandService.Contracts.Responses;
using CommandService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CommandService.Endpoints.Command;

public class GetForPlatform : EndpointBaseAsync
    .WithRequest<GetCommandForPlatformRequest>
    .WithActionResult<GetCommandForPlatformResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandRepository _repository;

    public GetForPlatform(IMapper mapper, ICommandRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    [SwaggerOperation(Tags = new[] {"CommandEndpoint"})]
    [HttpGet(ApiRoutes.Command.Get)]
    public override async Task<ActionResult<GetCommandForPlatformResponse>> HandleAsync(
        [FromQuery] GetCommandForPlatformRequest req,
        CancellationToken ct = default)
    {
        var response = await _repository.GetCommandAsync(req.PlatformId, req.CommandId, ct);

        if (response is null)
            return NotFound();

        return Ok(_mapper.Map<GetCommandForPlatformResponse>(response));
    }
}