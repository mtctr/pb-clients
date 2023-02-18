using FluentValidation;
using PB.Clients.API.Domain.Commands.Adapters;
using PB.Clients.API.Domain.Utils;

namespace PB.Clients.API.Domain.Validators
{
    internal class DeleteClientByEmailValidator : AbstractValidator<DeleteClientByEmailCommand>
    {
        public DeleteClientByEmailValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email must be filled.")
                .Matches(RegexValidations.Email).WithMessage("Must be a valid email");
        }
    }
}
