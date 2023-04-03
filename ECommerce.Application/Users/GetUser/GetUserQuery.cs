using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;

namespace ECommerce.Application.Users.GetUser
{
    public class GetUserQuery : BaseQuery<GetUserDto>
    {
        public GetUserQuery(long id)
        {
            this.Id = id;
        }

        public long Id { get; private set; }
    }
}
