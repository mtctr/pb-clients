using PB.Clients.API.Data.Repositories.Ports;
using PB.Clients.API.Domain.Commands.Adapters;
using PB.Clients.API.Domain.Commands.Ports;
using PB.Clients.API.Domain.Handlers.Ports;

namespace PB.Clients.API.Domain.Handlers.Adapters;

public class UpdateClientHandler : IHandler<UpdateClientCommand>
{
    private readonly IClientRepository _clientRepository;

    public UpdateClientHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public ICommandResult Handle(UpdateClientCommand command)
    {
        var validation = command.Validate();
        if (!validation.IsValid) return new CommandResult(false, validation.ToString(), null);

        if(EmailAlreadyExists(command.Email)) return new CommandResult(false, "This email is already being used, please insert another.", command.Email);

        var client = _clientRepository.GetById(command.Id);
        if (client is null)
            return new CommandResult(false, "Client could not be found.", command.Id);
        
        try
        {
            client.UpdateNameAndEmail(command.Name, command.Email);
            _clientRepository.Update(client);

            return new CommandResult(true, "Client updated successfully!", client);
        }catch(Exception ex)
        {
            return new CommandResult(false,ex.ToString(), null);
        }

    }

    private bool EmailAlreadyExists(string email)
    {
        var client = _clientRepository.GetByEmail(email);
        return client != null;
    }
}
