using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;

namespace ECommerce.Application.Orders.CancelOrder
{
    public class CancelOrderCommand : BaseCommand<OrderDto>
    {
        public CancelOrderCommand(string orderNumber)
        {
            this.OrderNumber = orderNumber;
        }

        public string OrderNumber { get; private set; }
    }
}
