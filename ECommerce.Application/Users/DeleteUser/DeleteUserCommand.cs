using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;

namespace ECommerce.Application.Users.DeleteUser
{
    public class DeleteUserCommand : BaseCommand<GenericIdDto>
    {
        public DeleteUserCommand(long id)
        {
            this.Id = id;
        }

        public long Id { get; private set; }
    }
}
