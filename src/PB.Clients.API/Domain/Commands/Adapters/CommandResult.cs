using PB.Clients.API.Domain.Commands.Ports;

namespace PB.Clients.API.Domain.Commands.Adapters;

public record CommandResult(bool Success, string Message, object? Data) : ICommandResult
{    
}
