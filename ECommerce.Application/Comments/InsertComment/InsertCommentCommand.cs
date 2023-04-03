using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;

namespace ECommerce.Application.Comments.InsertComment
{
    public class InsertCommentCommand : BaseCommand<GenericIdDto>
    {
        /*
         * User auth. akışı olmadığı için "UserId" request parameter olarak alınıyor.
         * Eğer JWT akışı olsaydı claim'lerden alınması gerekirdi.
         */
        public long UserId { get; set; }

        public long ProductId { get; set; }

        public string Message { get; set; }
    }
}
