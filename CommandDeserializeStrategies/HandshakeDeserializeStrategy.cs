using System.Text.Json;
using HushEcosystem.RpcModel.GlobalEvents;
using HushEcosystem.RpcModel.Handshake;
using Olimpo;

namespace HushEcosystem.RpcModel.CommandDeserializeStrategies;

public class HandshakeDeserializeStrategy : ICommandDeserializeStrategy
{
    private readonly IEventAggregator _eventAggregator;

    public HandshakeDeserializeStrategy(IEventAggregator eventAggregator)
    {
        this._eventAggregator = eventAggregator;
    }

    public bool CanHandle(string commandJson)
    {
        using (var jsonDocument = JsonDocument.Parse(commandJson))
        {
            var element = jsonDocument.RootElement;
            var command = element.GetProperty("Command").GetString();

            if (command == "HandshakeRequest")
            {
                return true;
            }

            return false;
        }
    }

    public async Task Handle(string commandJson)
    {
        var handShakeRequest = JsonSerializer.Deserialize<HandshakeRequest>(commandJson);

        if (handShakeRequest == null)
        {
            throw new InvalidOperationException($"Cannot deserialize the HandshakeRequest command: {commandJson}");
        }

        await this._eventAggregator.PublishAsync(new HandShakeRequestedEvent(handShakeRequest));
    }
}
