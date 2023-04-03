using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;

namespace ECommerce.Application.Orders.InProgressOrder
{
    public class InProgressOrderCommand : BaseCommand<OrderDto>
    {
        public InProgressOrderCommand(string orderNumber)
        {
            this.OrderNumber = orderNumber;
        }

        public string OrderNumber { get; private set; }
    }
}
