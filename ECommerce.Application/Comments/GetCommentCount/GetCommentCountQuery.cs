using ECommerce.Core.MessagingAdapter.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Application.Comments.GetCommentCount
{
    public class GetCommentCountQuery : BaseQuery<int>
    {
        /*
         * User auth. akışı olmadığı için "UserId" request parameter olarak alınıyor.
         * Eğer JWT akışı olsaydı claim'lerden alınması gerekirdi.
         */
        [FromQuery(Name = "userId")]
        public long? UserId { get; set; }

        [FromQuery(Name = "productId")]
        public long? ProductId { get; set; }
    }
}
