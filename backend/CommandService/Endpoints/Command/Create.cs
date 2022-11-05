using Ardalis.ApiEndpoints;
using AutoMapper;
using CommandService.Contracts;
using CommandService.Contracts.Requests;
using CommandService.Contracts.Responses;
using CommandService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CommandService.Endpoints.Command;

public class Create : EndpointBaseAsync
    .WithRequest<CreateCommandRequest>
    .WithActionResult<CreateCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandRepository _repository;

    public Create(IMapper mapper, ICommandRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    [SwaggerOperation(Tags = new[] {"CommandEndpoint"})]
    [HttpPost(ApiRoutes.Command.Create)]
    public override async Task<ActionResult<CreateCommandResponse>> HandleAsync(
        CreateCommandRequest req,
        CancellationToken ct = default)
    {
        var entity = _mapper.Map<Database.Entities.Command>(req);
        var response = await _repository.CreateCommandForPlatformAsync(req.PlatformId, entity, ct);

        if (response is null)
            return NotFound();

        return response.Value
            ? new ObjectResult(new CreateCommandResponse {Id = entity.Id}) {StatusCode = StatusCodes.Status201Created}
            : StatusCode(StatusCodes.Status304NotModified);
    }
}