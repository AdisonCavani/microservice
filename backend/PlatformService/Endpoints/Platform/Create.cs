using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Contracts;
using PlatformService.Contracts.Events;
using PlatformService.Contracts.Requests;
using PlatformService.Contracts.Responses;
using PlatformService.Repositories;
using PlatformService.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace PlatformService.Endpoints.Platform;

// TODO: CreatedAtRoute ???
public class Create : EndpointBaseAsync
    .WithRequest<CreatePlatformRequest>
    .WithActionResult<CreatePlatformResponse>
{
    private readonly IMapper _mapper;
    private readonly IPlatformRepository _repository;
    private readonly IMessageBusClient _messageBus;

    public Create(IMapper mapper, IPlatformRepository repository, IMessageBusClient messageBus)
    {
        _mapper = mapper;
        _repository = repository;
        _messageBus = messageBus;
    }

    [SwaggerOperation(Tags = new[] {"PlatformEndpoint"})]
    [HttpPost(ApiRoutes.Platform.Create)]
    public override async Task<ActionResult<CreatePlatformResponse>> HandleAsync(
        CreatePlatformRequest req,
        CancellationToken ct = default)
    {
        var entity = _mapper.Map<Database.Entities.Platform>(req);
        var result = await _repository.CreatePlatformAsync(entity, ct);

        try
        {
            var platformPublished = _mapper.Map<PlatformPublished>(entity);
            platformPublished.Event = "Platform_Published";
            _messageBus.PublishNewPlatform(platformPublished);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return result
            ? new ObjectResult(new CreatePlatformResponse {Id = entity.Id}) {StatusCode = StatusCodes.Status201Created}
            : StatusCode(StatusCodes.Status500InternalServerError);
    }
}