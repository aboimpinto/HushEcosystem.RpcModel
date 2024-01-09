using System.Text.Json;
using HushEcosystem.RpcModel.GlobalEvents;
using HushEcosystem.RpcModel.Handshake;
using Olimpo;

namespace HushEcosystem.RpcModel.CommandDeserializeStrategies;

public class HandshakeResponseDeserializeStrategy : ICommandDeserializeStrategy
{
    private readonly IEventAggregator _eventAggregator;

    public HandshakeResponseDeserializeStrategy(IEventAggregator eventAggregator)
    {
        this._eventAggregator = eventAggregator;
    }

    public bool CanHandle(string commandJson)
    {
        using (var jsonDocument = JsonDocument.Parse(commandJson))
        {
            var element = jsonDocument.RootElement;
            var command = element.GetProperty("Command").GetString();

            if (command == HandshakeResponse.CommandCode)
            {
                return true;
            }

            return false;
        }
    }

    public async Task Handle(string commandJson, string channelId)
    {
        var handshakeResponse = JsonSerializer.Deserialize<HandshakeResponse>(commandJson);

        if (handshakeResponse == null)
        {
            throw new InvalidOperationException($"Cannot deserialize the HandShakeResponse command: {commandJson}");
        }

        await this._eventAggregator.PublishAsync(new HandshakeResponseEvent(channelId, handshakeResponse));
    }
}
