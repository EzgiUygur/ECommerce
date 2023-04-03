using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;

namespace ECommerce.Application.Orders.InTransitOrder
{
    public class InTransitOrderCommand : BaseCommand<OrderDto>
    {
        public InTransitOrderCommand(string orderNumber)
        {
            this.OrderNumber = orderNumber;
        }

        public string OrderNumber { get; private set; }
    }
}
