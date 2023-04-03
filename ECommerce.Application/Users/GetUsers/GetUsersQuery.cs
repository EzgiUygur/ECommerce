using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Application.Users.GetUsers
{
    public class GetUsersQuery : BaseQuery<List<GetUserDto>>
    {
        [FromQuery(Name = "roleId")]
        public long? RoleId { get; set; }
    }
}

