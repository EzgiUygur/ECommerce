using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;

namespace ECommerce.Application.Users.GetUserBaskets
{
    public class GetUserBasketsQuery : BaseQuery<List<GetUserBasketDto>>
    {
        public GetUserBasketsQuery(long id)
        {
            this.Id = id;
        }

        public long Id { get; private set; }
    }
}
