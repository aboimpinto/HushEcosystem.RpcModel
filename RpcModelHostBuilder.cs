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
            services.AddSingleton<ICommandDeserializeStrategy, HandshakeRequestDeserializeStrategy>();
            services.AddSingleton<ICommandDeserializeStrategy, HandshakeResponseDeserializeStrategy>();
        });

        return builder;
    }
}

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterRpcModel(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ICommandDeserializeStrategy, HandshakeRequestDeserializeStrategy>();
        serviceCollection.AddSingleton<ICommandDeserializeStrategy, HandshakeResponseDeserializeStrategy>();

        return serviceCollection;
    }
}
