namespace ECommerce.Application.Responses
{
    public class GetOrderLineDto
    {
        public string OrderNumber { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
