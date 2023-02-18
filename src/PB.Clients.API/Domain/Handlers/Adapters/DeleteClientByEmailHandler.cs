using PB.Clients.API.Data.Repositories.Ports;
using PB.Clients.API.Domain.Commands.Adapters;
using PB.Clients.API.Domain.Commands.Ports;
using PB.Clients.API.Domain.Entities;
using PB.Clients.API.Domain.Handlers.Ports;

namespace PB.Clients.API.Domain.Handlers.Adapters;

public class DeleteClientByEmailHandler : IHandler<DeleteClientByEmailCommand>
{
    private readonly IClientRepository _clientRepository;

    public DeleteClientByEmailHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public ICommandResult Handle(DeleteClientByEmailCommand command)
    {
        var validation = command.Validate();
        if (!validation.IsValid) return new CommandResult(false, validation.ToString(), null);
                
        var client = _clientRepository.GetByEmail(command.Email);
        if(client is null)
            return new CommandResult(false, "Email does not exists in the database.", command.Email);

        try
        {
            _clientRepository.Delete(client);

            return new CommandResult(true, "Client deleted successfully!", client);
        }
        catch (Exception ex)
        {
            return new CommandResult(false, ex.ToString(), null);
        }

    }
}
