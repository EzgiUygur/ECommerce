using ECommerce.Core.Validation;
using FluentValidation;

namespace ECommerce.Application.Orders.InsertOrder
{
    public class InsertOrderCommandValidator : BaseValidator<InsertOrderCommand>
    {
        public InsertOrderCommandValidator()
        {
            this.RuleFor(x => x.UserId)
                .NotEmpty();

            this.RuleFor(x => x.Note)
                .MaximumLength(512);

            this.RuleFor(x => x.OrderLines)
                .NotEmpty();

            this.RuleForEach(x => x.OrderLines).ChildRules(x =>
            {
                x.RuleFor(x => x.ProductId)
                    .NotEmpty();

                x.RuleFor(x => x.Quantity)
                    .NotEmpty();
            });
        }
    }
}
