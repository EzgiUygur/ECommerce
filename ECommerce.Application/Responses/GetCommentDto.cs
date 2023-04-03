namespace ECommerce.Application.Responses
{
    public class GetCommentDto
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long ProductId { get; set; }

        public string Message { get; set; }
    }
}
