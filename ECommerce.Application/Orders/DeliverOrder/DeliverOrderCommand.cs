using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;

namespace ECommerce.Application.Orders.DeliverOrder
{
    public class DeliverOrderCommand : BaseCommand<OrderDto>
    {
        public DeliverOrderCommand(string orderNumber)
        {
            this.OrderNumber = orderNumber;
        }

        public string OrderNumber { get; private set; }
    }
}
