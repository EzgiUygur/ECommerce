using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;

namespace ECommerce.Application.Users.CreateUser
{
    public class CreateUserCommand : BaseCommand<GenericIdDto>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public long RoleId { get; set; }
    }
}
