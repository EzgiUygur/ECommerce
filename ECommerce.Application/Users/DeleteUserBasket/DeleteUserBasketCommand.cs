using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;

namespace ECommerce.Application.Users.DeleteUserBasket
{
    public class DeleteUserBasketCommand : BaseCommand<GenericIdDto>
    {
        public DeleteUserBasketCommand(long id)
        {
            this.Id = id;
        }

        public long Id { get; private set; }
    }
}
