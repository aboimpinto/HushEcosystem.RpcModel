using HushEcosystem.RpcModel.Handshake;

namespace HushEcosystem.RpcModel.GlobalEvents;

public class HandShakeRequestedEvent
{
    public string ChannelId { get; } = string.Empty;

    public HandshakeRequest HandshakeRequest { get; }

    public HandShakeRequestedEvent(string channerId, HandshakeRequest handShakeRequest)
    {
        this.ChannelId = channerId;
        this.HandshakeRequest = handShakeRequest;
    }
}