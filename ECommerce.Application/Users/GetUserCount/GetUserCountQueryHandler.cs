using ECommerce.Core.MessagingAdapter.Queries;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Users.GetUserCount
{
    public class GetUserCountQueryHandler : BaseQueryHandler<GetUserCountQuery, int>
    {
        private readonly ApplicationDbContext _context;

        public GetUserCountQueryHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<int> Handle(GetUserCountQuery request, CancellationToken cancellationToken)
        {
            var query = this._context.Set<User>().AsQueryable();

            if (request.RoleId != null)
            {
                query = query.Where(x => x.RoleId == request.RoleId);
            }

            return await query.CountAsync(cancellationToken);
        }
    }
}
