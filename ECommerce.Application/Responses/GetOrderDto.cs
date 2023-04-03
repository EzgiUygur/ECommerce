using ECommerce.Domain.Enums;

namespace ECommerce.Application.Responses
{
    public class GetOrderDto
    {
        public string OrderNumber { get; set; }

        public OrderStatus Status { get; set; }

        public string Note { get; set; }

        public long UserId { get; set; }
    }
}
