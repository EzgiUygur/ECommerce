using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Users.GetUsers
{
    public class GetUsersQueryHandler : BaseQueryHandler<GetUsersQuery, List<GetUserDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetUsersQueryHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<List<GetUserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var query = this._context.Set<User>()
                .AsNoTracking()
                .AsQueryable();

            if (request.RoleId != null)
            {
                query = query.Where(x => x.RoleId == request.RoleId);
            }

            var response = await query.Select(x => new GetUserDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Password = x.Password,
                Email = x.Email,
                RoleId = x.RoleId
            }).ToListAsync(cancellationToken);

            return response;
        }
    }
}

