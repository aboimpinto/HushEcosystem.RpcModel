using HushEcosystem.RpcModel.Handshake;

namespace HushEcosystem.RpcModel.GlobalEvents;

public class HandShakeRequestedEvent
{
    public HandshakeRequest HandshakeRequest { get; }

    public HandShakeRequestedEvent(HandshakeRequest handShakeRequest)
    {
        this.HandshakeRequest = handShakeRequest;
    }
}