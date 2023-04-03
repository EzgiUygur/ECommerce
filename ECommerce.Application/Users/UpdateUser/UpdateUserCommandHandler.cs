using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Users.UpdateUser
{
    public class UpdateUserCommandHandler : BaseCommandHandler<UpdateUserCommand, GenericIdDto>
    {
        private readonly ApplicationDbContext _context;

        public UpdateUserCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<GenericIdDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await this._context.Set<User>()
                .FirstOrDefaultAsync(x =>
                    x.Id == request.Id, cancellationToken)
                ?? throw new KeyNotFoundException("İlgili kullanıcı bulunamadı.");

            var existUser = await this._context.Set<User>()
                .AnyAsync(x =>
                    x.Email == request.Email,
                    cancellationToken);

            if (existUser)
            {
                throw new Exception("Bu mail adresi kayıtlı.");
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Password = request.Password;
            user.Email = request.Email;
            user.RoleId = request.RoleId;

            this._context.Update(user);
            await this._context.SaveChangesAsync(cancellationToken);

            return new GenericIdDto(user.Id);
        }
    }
}
