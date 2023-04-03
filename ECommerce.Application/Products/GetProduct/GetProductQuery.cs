using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;

namespace ECommerce.Application.Products.GetProduct
{
    public class GetProductQuery : BaseQuery<GetProductDto>
    {
        public GetProductQuery(long id)
        {
            this.Id = id;
        }

        public long Id { get; private set; }
    }
}
