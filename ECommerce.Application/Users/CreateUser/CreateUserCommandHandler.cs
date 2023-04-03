using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Users.CreateUser
{
    public class CreateUserCommandHandler : BaseCommandHandler<CreateUserCommand, GenericIdDto>
    {
        private readonly ApplicationDbContext _context;

        public CreateUserCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<GenericIdDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existUser = await this._context.Set<User>()
                .AnyAsync(x => x.Email == request.Email, cancellationToken);

            if (existUser)
            {
                throw new Exception("Kullanıcı daha önce oluşturulmuş.");
            }

            var existRole = await this._context.Set<Role>()
                .AnyAsync(x => x.Id == request.RoleId, cancellationToken);

            if (!existRole)
            {
                throw new Exception("İlgili role bulunamadı.");
            }

            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                Email = request.Email,
                RoleId = request.RoleId,
                UserDetail = new UserDetail(),
            };

            await this._context.AddAsync(user, cancellationToken);
            await this._context.SaveChangesAsync(cancellationToken);

            return new GenericIdDto(user.Id);
        }
    }
}

