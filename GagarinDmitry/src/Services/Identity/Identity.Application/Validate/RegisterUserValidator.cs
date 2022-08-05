using FluentValidation;
using Identity.Application.Models;

namespace Identity.Application.Validate
{
    /// <summary>
    /// <see cref="RegisterUserModel"/> validator.
    /// </summary>
    public class RegisterUserValidator : AbstractValidator<RegisterUserModel>
    {
        /// <summary>
        /// Initializes a new <see cref="RegisterUserValidator"/> instance.
        /// </summary>
        public RegisterUserValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20)
                .Matches("^[a-zA-Z0-9]*$");

            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20)
                .Matches("^[a-zA-Z]*$");

            RuleFor(x => x.SecondName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20)
                .Matches("^[a-zA-Z]*$");

            RuleFor(x => x.Password)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(20)
                .Matches("^[a-zA-Z0-9]*$");

            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress();

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .Matches(@"^[+]?[(]?[0-9]{3}[)]?[-\s.]?[0-9]{3}[-\s.]?[0-9]{4,6}$");

            RuleFor(x => x.Age)
                .NotNull()
                .GreaterThan(12);

            RuleFor(x => x.AccountBalance)
                .NotNull()
                .LessThan(50000);
        }
    }
}
