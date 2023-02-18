using PB.Clients.API.Data.Repositories.Ports;
using PB.Clients.API.Domain.Commands.Adapters;
using PB.Clients.API.Domain.Entities;
using PB.Clients.API.Domain.Handlers.Adapters;
using PB.Clients.API.Domain.Handlers.Ports;
using PB.Clients.Tests.Fakes;

namespace PB.Clients.Tests.CreateClient;

public class CreateClientHandlerTests
{
    private readonly IClientRepository _clientRepository;
	private readonly IHandler<CreateClientCommand> _createClientHandler;

	private readonly string _existingEmail = "existing@email.com";
	public CreateClientHandlerTests()
	{
		_clientRepository = new FakeClientRepository();
		_createClientHandler = new CreatClientHandler(_clientRepository);
			
		var existingClient = new Client("Existing Client", _existingEmail);
		_clientRepository.Add(existingClient);
	}

	[Fact]
	public void Success_should_be_false_if_command_is_invalid()
	{
		var invalidCommand = new CreateClientCommand()
		{
			Name = "foo",
			Email = "bar",
        };
		var result = _createClientHandler.Handle(invalidCommand) as CommandResult;
		Assert.False(result.Success, result.Message);
	}

	[Fact]
	public void Success_should_be_false_if_email_already_exists_in_database()
	{
        var command = new CreateClientCommand()
        {
            Name = "Full Name",
            Email = _existingEmail,
        };
        var result = _createClientHandler.Handle(command) as CommandResult;
        Assert.False(result.Success, result.Message);
    }

	[Fact]
	public void Success_should_be_true_if_command_is_valid_and_email_does_not_exist()
	{
        var command = new CreateClientCommand()
        {
            Name = "Full Name",
            Email = "valid@email.com",
        };
        var result = _createClientHandler.Handle(command) as CommandResult;
        Assert.True(result.Success, result.Message);
    }
}
