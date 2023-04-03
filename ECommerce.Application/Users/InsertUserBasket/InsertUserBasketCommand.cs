using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;

namespace ECommerce.Application.Users.InsertUserBasket
{
    public class InsertUserBasketCommand : BaseCommand<GenericIdDto>
    {
        /*
         * User auth. akışı olmadığı için "UserId" request parameter olarak alınıyor.
         * Eğer JWT akışı olsaydı claim'lerden alınması gerekirdi.
         */
        public long UserId { get; set; }

        public long ProductId { get; set; }

        public uint Quantity { get; set; }
    }
}
