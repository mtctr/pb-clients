using FluentValidation;
using PB.Clients.API.Domain.Commands.Adapters;
using PB.Clients.API.Domain.Utils;

namespace PB.Clients.API.Domain.Validators
{
    internal class UpdateClientValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id must be sent");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must be filled.")
                .Must(name => name?.Split(" ").Count() > 1).WithMessage("Must be a full name.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email must be filled.")
                .Matches(RegexValidations.Email).WithMessage("Must be a valid email");
        }
    }
}
