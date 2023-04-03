using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;

namespace ECommerce.Application.Comments.UpdateComment
{
    public class UpdateCommentCommand : BaseCommand<GenericIdDto>
    {
        public long Id { get; set; }

        public string Message { get; set; }
    }
}
