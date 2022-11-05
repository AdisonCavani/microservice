using AutoMapper;
using CommandService.Database.Entities;
using CommandService.Settings;
using Grpc.Net.Client;
using Microsoft.Extensions.Options;
using PlatformService;

namespace CommandService.Services;

public class PlatformDataClient : IPlatformDataClient
{
    private readonly IMapper _mapper;
    private readonly IOptionsSnapshot<ConnectionSettings> _options;

    public PlatformDataClient(IMapper mapper, IOptionsSnapshot<ConnectionSettings> options)
    {
        _mapper = mapper;
        _options = options;
    }

    public async Task<IEnumerable<Platform>> ReturnAllPlatforms()
    {
        var channel = GrpcChannel.ForAddress(_options.Value.GrpcPlatformService);
        var client = new GrpcPlatform.GrpcPlatformClient(channel);

        var platforms = new List<Platform>();

        for(int i = 1;; i++)
        {
            var req = new GetAllPlatformsGrpcRequest
            {
                Page = i
            };
            
            try
            {
                var reply = await client.GetAllPlatformsAsync(req);
                platforms.AddRange(_mapper.Map<IEnumerable<Platform>>(reply.Platforms));

                if (i >= reply.PagesCount)
                    break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        return platforms;
    }
}