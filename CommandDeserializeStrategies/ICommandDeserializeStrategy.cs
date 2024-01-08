namespace HushEcosystem.RpcModel.CommandDeserializeStrategies;

public interface ICommandDeserializeStrategy
{
    bool CanHandle(string commandJson);

    Task Handle(string commandJson, string channelId);
}
