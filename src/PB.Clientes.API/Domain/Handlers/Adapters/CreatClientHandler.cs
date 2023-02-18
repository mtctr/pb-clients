using PB.Clients.API.Data.Repositories.Ports;
using PB.Clients.API.Domain.Commands.Adapters;
using PB.Clients.API.Domain.Commands.Ports;
using PB.Clients.API.Domain.Entities;
using PB.Clients.API.Domain.Handlers.Ports;

namespace PB.Clients.API.Domain.Handlers.Adapters;

public class CreatClientHandler : IHandler<CreateClientCommand>
{
    private readonly IClientRepository _clientRepository;

    public CreatClientHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public ICommandResult Handle(CreateClientCommand command)
    {
        var validation = command.Validate();
        if (!validation.IsValid) return new CommandResult(false, validation.ToString(), null);

        if(EmailAlreadyExists(command.Email)) return new CommandResult(false, "This email is already being used, please insert another.", command.Email);

        try
        {
            var client = new Client(command.Name, command.Email);
            _clientRepository.Add(client);

            return new CommandResult(true, "Client created successfully!", client);
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
