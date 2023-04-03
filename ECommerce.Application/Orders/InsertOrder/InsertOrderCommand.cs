using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;

namespace ECommerce.Application.Orders.InsertOrder
{
    public class InsertOrderCommand : BaseCommand<OrderDto>
    {
        /*
         * User auth. akışı olmadığı için "UserId" request parameter olarak alınıyor.
         * Eğer JWT akışı olsaydı claim'lerden alınması gerekirdi.
         */
        public long UserId { get; set; }

        public string Note { get; set; }

        public IList<OrderCommandOrderLine> OrderLines { get; set; }
    }

    public class OrderCommandOrderLine
    {
        public uint Quantity { get; set; }

        public long ProductId { get; set; }
    }
}
