using ECommerce.Core.Constants;
using ECommerce.Core.Validation;
using FluentValidation;

namespace ECommerce.Application.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : BaseValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
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
