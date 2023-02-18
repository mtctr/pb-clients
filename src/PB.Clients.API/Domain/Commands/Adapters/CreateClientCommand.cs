using FluentValidation.Results;
using PB.Clients.API.Domain.Commands.Ports;
using PB.Clients.API.Domain.Validators;

namespace PB.Clients.API.Domain.Commands.Adapters
{
    public class CreateClientCommand : ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ValidationResult Validate()
        {
            var validator = new CreateClientValidator();
            return validator.Validate(this);
        }
    }
}
