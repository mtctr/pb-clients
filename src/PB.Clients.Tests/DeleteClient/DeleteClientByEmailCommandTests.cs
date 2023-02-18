using PB.Clients.API.Domain.Commands.Adapters;

namespace PB.Clients.Tests.DeleteClient;

public class DeleteClientByEmailCommandTests
{
    private readonly string _validEmail = "valid@email.com";
    
    [Theory]
    [InlineData("invalid_email")]
    [InlineData("invalid_email.com")]
    [InlineData("invalid_email@")]
    [InlineData("invalid_email@.com")]
    [InlineData("invalid_email@com")]
    public void Command_must_be_invalid_if_email_is_not_valid(string email)
    {
        var command = new DeleteClientByEmailCommand
        {
            Email = email
        };
        
        var validation = command.Validate();
        Assert.False(validation.IsValid, validation.ToString());
    }

    [Fact]
    public void Command_must_be_valid_if_email_is_valid()
    {
        var command = new DeleteClientByEmailCommand
        {
            Email = _validEmail
        };

        var validation = command.Validate();
        Assert.True(validation.IsValid, validation.ToString());
    }
}
