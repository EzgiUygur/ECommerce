using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;

namespace ECommerce.Application.Users.UpdateUser
{
    public class UpdateUserCommand : BaseCommand<GenericIdDto>
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public long RoleId { get; set; }
    }
}
