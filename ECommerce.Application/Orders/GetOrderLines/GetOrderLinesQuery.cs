using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;

namespace ECommerce.Application.Orders.GetOrderLines
{
    public class GetOrderLinesQuery : BaseQuery<List<GetOrderLineDto>>
    {
        public GetOrderLinesQuery(string orderNumber)
        {
            this.OrderNumber = orderNumber;
        }

        public string OrderNumber { get; private set; }
    }
}
