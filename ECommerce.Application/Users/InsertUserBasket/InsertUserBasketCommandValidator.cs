using ECommerce.Core.Validation;
using FluentValidation;

namespace ECommerce.Application.Users.InsertUserBasket
{
    public class InsertUserBasketCommandValidator : BaseValidator<InsertUserBasketCommand>
    {
        public InsertUserBasketCommandValidator()
        {
            this.RuleFor(x => x.UserId)
                .NotEmpty();

            this.RuleFor(x => x.ProductId)
                .NotEmpty();

            this.RuleFor(x => x.Quantity)
                .NotEmpty();
        }
    }
}
