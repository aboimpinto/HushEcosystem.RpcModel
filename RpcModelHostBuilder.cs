using HushEcosystem.RpcModel.CommandDeserializeStrategies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HushEcosystem;

public static class RpcModelHostBuilder
{
    public static IHostBuilder RegisterRpcModel(this IHostBuilder builder)
    {
        builder.ConfigureServices((hostContext, services) =>
        {
            services.AddSingleton<ICommandDeserializeStrategy, HandshakeDeserializeStrategy>();
        });

        return builder;
    }
}
