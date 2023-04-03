namespace ECommerce.Application.Responses
{
    public class GetUserBasketDto
    {
        public long Id { get; set; }

        public int Quantity { get; set; }

        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
