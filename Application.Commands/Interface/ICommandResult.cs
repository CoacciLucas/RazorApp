namespace Application.Commands.Interface;

public interface ICommandResult
{
    bool Success { get; }
    string Message { get; }
    object Data { get; }
}
