using System.Text.Json;
using HushEcosystem.RpcModel.GlobalEvents;
using HushEcosystem.RpcModel.Handshake;
using Olimpo;

namespace HushEcosystem.RpcModel.CommandDeserializeStrategies;

public class HandshakeRequestDeserializeStrategy : ICommandDeserializeStrategy
{
    private readonly IEventAggregator _eventAggregator;

    public HandshakeRequestDeserializeStrategy(IEventAggregator eventAggregator)
    {
        this._eventAggregator = eventAggregator;
    }

    public bool CanHandle(string commandJson)
    {
        using (var jsonDocument = JsonDocument.Parse(commandJson))
        {
            var element = jsonDocument.RootElement;
            var command = element.GetProperty("Command").GetString();

            if (command == HandshakeRequest.CommandCode)
            {
                return true;
            }

            return false;
        }
    }

    public async Task Handle(string commandJson, string channelId)
    {
        var handShakeRequest = JsonSerializer.Deserialize<HandshakeRequest>(commandJson);

        if (handShakeRequest == null)
        {
            throw new InvalidOperationException($"Cannot deserialize the HandshakeRequest command: {commandJson}");
        }

        await this._eventAggregator.PublishAsync(new HandshakeRequestedEvent(channelId, handShakeRequest));
    }
}
