
using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Users.DeleteUser
{
    public class DeleteUserCommandHandler : BaseCommandHandler<DeleteUserCommand, GenericIdDto>
    {
        private readonly ApplicationDbContext _context;

        public DeleteUserCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<GenericIdDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var existUser = await this._context.Set<User>()
               .FirstOrDefaultAsync(x =>
                   x.Id == request.Id,
                   cancellationToken);

            /*
             * RESTful gereği idempotency sağlandı.
             */
            if (existUser==null)
            {
                return new GenericIdDto(request.Id);
            }

            this._context.Remove(existUser);
            await this._context.SaveChangesAsync(cancellationToken);

            return new GenericIdDto(request.Id);
        }
    }
}
