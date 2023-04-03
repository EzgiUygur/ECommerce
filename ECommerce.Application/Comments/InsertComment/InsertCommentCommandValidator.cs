using ECommerce.Core.Validation;
using FluentValidation;

namespace ECommerce.Application.Comments.InsertComment
{
    public class InsertCommentCommandValidator : BaseValidator<InsertCommentCommand>
    {
        public InsertCommentCommandValidator()
        {
            this.RuleFor(x => x.UserId)
                .NotEmpty();

            this.RuleFor(x => x.ProductId)
                .NotEmpty();

            this.RuleFor(x => x.Message)
                .NotEmpty()
                .MaximumLength(512);
        }
    }
}
