using PB.Clients.API.Data.Repositories.Ports;
using PB.Clients.API.Domain.Commands.Adapters;
using PB.Clients.API.Domain.Entities;
using PB.Clients.API.Domain.Handlers.Adapters;
using PB.Clients.API.Domain.Handlers.Ports;
using PB.Clients.Tests.Fakes;

namespace PB.Clients.Tests.DeleteClient;

public class DeleteClientByEmailHandlerTests
{
    private readonly IClientRepository _clientRepository;
    private readonly IHandler<DeleteClientByEmailCommand> _deleteClientHandler;

    private readonly string _existingEmail = "existing@email.com";
    private readonly string _notExistingEmail = "not_existing@email.com";
    
    public DeleteClientByEmailHandlerTests()
    {
        _clientRepository = new FakeClientRepository();
        _deleteClientHandler = new DeleteClientByEmailHandler(_clientRepository);

        var existingClient = new Client("Existing Client", _existingEmail);
        _clientRepository.Add(existingClient);
    }
    [Fact]
    public void Success_should_be_false_if_command_is_invalid()
    {
        var invalidCommand = new DeleteClientByEmailCommand
        {
            Email = "invalid@email"
        };

        var result = _deleteClientHandler.Handle(invalidCommand) as CommandResult;
        Assert.False(result.Success, result.Message);
    }

    [Fact]
    public void Success_should_be_false_if_email_does_not_exist()
    {
        var command = new DeleteClientByEmailCommand
        {
            Email = _notExistingEmail
        };

        var result = _deleteClientHandler.Handle(command) as CommandResult;
        Assert.False(result.Success, result.Message);
    }

    [Fact]
    public void Success_should_be_true_if_email_exists()
    {
        var command = new DeleteClientByEmailCommand
        {
            Email = _existingEmail
        };

        var result = _deleteClientHandler.Handle(command) as CommandResult;
        Assert.True(result.Success, result.Message);
    }

}
