namespace ECommerce.Application.Responses
{
    public class GenericIdDto
    {
        public GenericIdDto(long id)
        {
            this.Id = id;
        }

        public long Id { get; private set; }
    }
}
