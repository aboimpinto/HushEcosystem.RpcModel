using System.Text.Json;

namespace HushEcosystem.RpcModel.Handshake;

public class HandshakeRequest : CommandBase
{
    public ClientType ClientType { get; set; }

    public string NodeId { get; set; } = string.Empty;

    public string NodeResonsabileAddress { get; set; } = string.Empty;

    public string Property1 { get; set; } = string.Empty;
    public string Property2 { get; set; } = string.Empty;
    public string Property3 { get; set; } = string.Empty;
    public string Property4 { get; set; } = string.Empty;
    public string Property5 { get; set; } = string.Empty;
    public string Property6 { get; set; } = string.Empty;
    public string Property7 { get; set; } = string.Empty;
    public string Property8 { get; set; } = string.Empty;
    public string Property9 { get; set; } = string.Empty;
    public string Property10 { get; set; } = string.Empty;

    public HandshakeRequest()
    {
        this.Command = "HandshakeRequest";
    }

    public override string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
}
