using System.Text.Json;

namespace HushEcosystem.RpcModel.Handshake;

public class HandshakeResponse : CommandBase
{
    public bool Result { get; set; }

    public string FailureReason { get; set; } = string.Empty;

    public HandshakeResponse()
    {
        this.Command = "HandshakeResponse";
    }

    public override string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}
