using ECommerce.Core.Validation;
using FluentValidation;

namespace ECommerce.Application.Comments.UpdateComment
{
    public class UpdateCommentCommandValidator : BaseValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            this.RuleFor(x => x.Message)
                .NotEmpty()
                .MaximumLength(512);
        }
    }
}
