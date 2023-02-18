using FluentValidation.Results;

namespace PB.Clients.API.Domain.Commands.Ports;

public interface ICommand
{
    ValidationResult Validate();
}
