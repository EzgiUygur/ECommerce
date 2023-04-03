using ECommerce.Core.Validation;
using FluentValidation;

namespace ECommerce.Application.Users.CreateUser
{
    public class CreateUserCommandValidator : BaseValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            this.RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Ad alanı boş olamaz.");

            this.RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Soyad alanı boş olamaz.");

            this.RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage("Parola alanı boş olamaz.")
                .Length(6, 25)
                    .WithMessage("Parola Alanı 6 ile 25 karakter arasında olmalıdır.");

            this.RuleFor(x => x.Email)
                .NotEmpty()
                    .WithMessage("Mail alanı boş olamaz.")
                .EmailAddress()
                    .WithMessage("Geçerli bir eposta adresi giriniz.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            this.RuleFor(x => x.RoleId)
                .NotEmpty();
        }
    }
}

