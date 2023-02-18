using PB.Clients.API.Domain.Commands.Adapters;

namespace PB.Clients.Tests.UpdateClient;

public class UpdateClientCommandTests
{
    private readonly string _validId = Guid.NewGuid().ToString();
    private readonly string _validName = "Full Name";
    private readonly string _validEmail = "valid@email.com";

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("  ")]
    public void Command_must_be_invalid_if_id_is_empty_or_whitespace(string id)
    {
        var command = new UpdateClientCommand()
        {
            Id = id,
            Name = _validName,
            Email = _validEmail
        };
        var validation = command.Validate();
        Assert.False(validation.IsValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("  ")]
    public void Command_must_be_invalid_if_email_is_empty_or_whitespace(string email)
    {
        var command = new UpdateClientCommand()
        {
            Id = _validId,
            Name = _validName,
            Email = email
        };
        var validation = command.Validate();
        Assert.False(validation.IsValid);
    }

    [Theory]
    [InlineData("invalid_email")]
    [InlineData("invalid_email.com")]
    [InlineData("invalid_email@")]
    [InlineData("invalid_email@.com")]
    [InlineData("invalid_email@com")]
    public void Command_must_be_invalid_if_email_is_not_a_valid_email(string email)
    {
        var command = new UpdateClientCommand()
        {
            Id = _validId,
            Name = _validName,
            Email = email
        };
        var validation = command.Validate();
        Assert.False(validation.IsValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("  ")]
    public void Command_must_be_invalid_if_name_is_empty(string name)
    {
        var command = new UpdateClientCommand()
        {
            Id = _validId,
            Name = name,
            Email = _validEmail
        };
        var validation = command.Validate();
        Assert.False(validation.IsValid);
    }
    
    [Theory]
    [InlineData("FirstName")]        
    public void Command_must_be_invalid_if_name_is_not_full_name(string name)
    {
        var command = new UpdateClientCommand()
        {
            Id = _validId,
            Name = name,
            Email = _validEmail
        };
        var validation = command.Validate();
        Assert.False(validation.IsValid);
    }

    [Fact]
    public void Command_must_be_valid_if_name_is_full_name_and_email_is_valid()
    {
        var command = new UpdateClientCommand()
        {
            Id = _validId,
            Name = _validName,
            Email = _validEmail
        };
        var validation = command.Validate();
        Assert.True(validation.IsValid, validation.ToString());
    }
}
