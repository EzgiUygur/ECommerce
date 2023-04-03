using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Users.GetUser
{
    public class GetUserQueryHandler : BaseQueryHandler<GetUserQuery, GetUserDto>
    {
        private readonly ApplicationDbContext _context;

        public GetUserQueryHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<GetUserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var response = await this._context.Set<User>()
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Join(
                    this._context.Set<Role>(),
                    user => user.RoleId,
                    role => role.Id,
                    (user, role) => new { user, role })
                .Select(x => new GetUserDto()
                {
                    Id = x.user.Id,
                    FirstName = x.user.FirstName,
                    LastName = x.user.LastName,
                    Password = x.user.Password,
                    Email = x.user.Email,
                    RoleId = x.user.RoleId,
                    RoleName = x.role.Name
                })
                .FirstOrDefaultAsync(cancellationToken)
                ?? throw new KeyNotFoundException();

            return response;
        }
    }
}
