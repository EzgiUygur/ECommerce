using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;
using ECommerce.Domain.Enums;

namespace ECommerce.Application.Users.UpdateUserDetail
{
    public class UpdateUserDetailCommand : BaseCommand<GenericIdDto>
    {
        public long UserId { get; set; }

        public string PhoneNumber { get; set; }

        public string WorkPhoneNumber { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
