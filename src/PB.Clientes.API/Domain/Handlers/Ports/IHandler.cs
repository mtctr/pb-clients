using PB.Clients.API.Domain.Commands.Ports;

namespace PB.Clients.API.Domain.Handlers.Ports;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}
