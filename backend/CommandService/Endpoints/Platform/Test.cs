using Ardalis.ApiEndpoints;
using CommandService.Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CommandService.Endpoints.Platform;

public class Test : EndpointBaseSync
    .WithoutRequest
    .WithActionResult
{
    [SwaggerOperation(Tags = new[] {"PlatformEndpoint"})]
    [HttpGet(ApiRoutes.Platform.Test)]
    public override ActionResult Handle()
    {
        return Ok();
    }
}