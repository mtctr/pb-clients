using FluentValidation.Results;
using PB.Clients.API.Domain.Commands.Ports;
using PB.Clients.API.Domain.Validators;

namespace PB.Clients.API.Domain.Commands.Adapters
{
    public class DeleteClientByEmailCommand : ICommand
    {
        public string Email { get; set; }

        public ValidationResult Validate()
        {
            var validator = new DeleteClientByEmailValidator();
            return validator.Validate(this);
        }
    }
}
