using HushEcosystem.RpcModel.Handshake;

namespace HushEcosystem.RpcModel.GlobalEvents;

public class HandshakeRequestedEvent
{
    public string ChannelId { get; } = string.Empty;

    public HandshakeRequest HandshakeRequest { get; }

    public HandshakeRequestedEvent(string channerId, HandshakeRequest handShakeRequest)
    {
        this.ChannelId = channerId;
        this.HandshakeRequest = handShakeRequest;
    }
}