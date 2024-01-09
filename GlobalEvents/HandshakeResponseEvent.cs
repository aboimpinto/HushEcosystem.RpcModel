using HushEcosystem.RpcModel.Handshake;

namespace HushEcosystem.RpcModel.GlobalEvents;

public class HandshakeResponseEvent
{
    public string ChannelId { get; } = string.Empty;

    public HandshakeResponse HandshakeResponse { get; }

    public HandshakeResponseEvent(string channerId, HandshakeResponse handshakeResponse)
    {
        this.ChannelId = channerId;
        this.HandshakeResponse = handshakeResponse;
    }
}