using ECommerce.Core.MessagingAdapter.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Application.Users.GetUserCount
{
    public class GetUserCountQuery : BaseQuery<int>
    {
        [FromQuery(Name = "roleId")]
        public long? RoleId { get; set; }
    }
}
