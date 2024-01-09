using System.Text.Json;

namespace HushEcosystem.RpcModel.Handshake;

public class HandshakeResponse : CommandBase
{
    public static string CommandCode = "HandshakeResponse";

    public bool Result { get; set; }

    public string FailureReason { get; set; } = string.Empty;

    public HandshakeResponse()
    {
        this.Command = CommandCode;
    }

    public override string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}
