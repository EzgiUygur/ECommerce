using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;

namespace ECommerce.Application.Orders.GetOrder
{
    public class GetOrderQuery : BaseQuery<GetOrderDto>
    {
        public GetOrderQuery(string orderNumber)
        {
            this.OrderNumber = orderNumber;
        }

        public string OrderNumber { get; private set; }
    }
}
