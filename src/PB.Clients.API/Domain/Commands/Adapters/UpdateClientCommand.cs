using FluentValidation.Results;
using PB.Clients.API.Domain.Commands.Ports;
using PB.Clients.API.Domain.Validators;

namespace PB.Clients.API.Domain.Commands.Adapters
{
    public class UpdateClientCommand : ICommand
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ValidationResult Validate()
        {
            var validator = new UpdateClientValidator();
            return validator.Validate(this);
        }
    }
}
