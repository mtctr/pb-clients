using PB.Clients.API.Data.Repositories.Ports;
using PB.Clients.API.Domain.Commands.Adapters;
using PB.Clients.API.Domain.Entities;
using PB.Clients.API.Domain.Handlers.Adapters;
using PB.Clients.API.Domain.Handlers.Ports;
using PB.Clients.Tests.Fakes;

namespace PB.Clients.Tests.UpdateClient;

public class UpdateClientHandlerTests
{
    private readonly IClientRepository _clientRepository;
	private readonly IHandler<UpdateClientCommand> _updateClientHandler;

	private readonly string _existingEmail = "existing@email.com";
	private readonly string _existingId;
	public UpdateClientHandlerTests()
	{
		_clientRepository = new FakeClientRepository();
		_updateClientHandler = new UpdateClientHandler(_clientRepository);
			
		var existingClient = new Client("Existing Client", _existingEmail);
		_existingId = existingClient.Id.ToString();
		_clientRepository.Add(existingClient);
	}

	[Fact]
	public void Success_should_be_false_if_command_is_invalid()
	{
		var invalidCommand = new UpdateClientCommand()
		{
			Id = "",
			Name = "foo",
			Email = "bar",
        };
		
		var result = _updateClientHandler.Handle(invalidCommand) as CommandResult;
		Assert.False(result.Success, result.Message);
	}

	[Fact]
	public void Success_should_be_false_if_client_does_not_exists()
	{
        var invalidCommand = new UpdateClientCommand()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Full Name",
            Email = "email@email.com",
        };

        var result = _updateClientHandler.Handle(invalidCommand) as CommandResult;
        Assert.False(result.Success, result.Message);
    }
	[Fact]
	public void Success_should_be_false_if_email_already_exists_in_database()
	{
        var command = new UpdateClientCommand()
        {
			Id = _existingId,
            Name = "Full Name",
            Email = _existingEmail,
        };
        
		var result = _updateClientHandler.Handle(command) as CommandResult;
        Assert.False(result.Success, result.Message);
    }

	[Fact]
	public void Success_should_be_true_if_command_is_valid_and_email_does_not_exist()
	{
        var command = new UpdateClientCommand()
        {
			Id = _existingId,
            Name = "Full Name",
            Email = "valid@email.com",
        };
        
		var result = _updateClientHandler.Handle(command) as CommandResult;
        Assert.True(result.Success, result.Message);
    }
}
