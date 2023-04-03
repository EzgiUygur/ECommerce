using ECommerce.Core.Constants;
using ECommerce.Core.Validation;
using FluentValidation;

namespace ECommerce.Application.Products.InsertProduct
{
    public class InsertProductCommandValidator : BaseValidator<InsertProductCommand>
    {
        public InsertProductCommandValidator()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty()
                .Matches(Validations.NameExpression);

            this.RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThan(0);

            this.RuleFor(x => x.Stock)
                .NotEmpty();
        }
    }
}
