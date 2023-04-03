namespace ECommerce.Application.Responses
{
    public class OrderDto
    {
        public OrderDto(string orderNumber)
        {
            this.OrderNumber = orderNumber;
        }

        public string OrderNumber { get; private set; }
    }
}
