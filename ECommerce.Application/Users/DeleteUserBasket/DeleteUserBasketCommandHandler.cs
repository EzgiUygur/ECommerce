using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Users.DeleteUserBasket
{
    public class DeleteUserBasketCommandHandler : BaseCommandHandler<DeleteUserBasketCommand, GenericIdDto>
    {
        private readonly ApplicationDbContext _context;

        public DeleteUserBasketCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<GenericIdDto> Handle(DeleteUserBasketCommand request, CancellationToken cancellationToken)
        {
            var existUserbasket = await this._context.Set<UserBasket>()
               .AnyAsync(x =>
                   x.Id == request.Id,
                   cancellationToken);

            /*
             * RESTful gereği idempotency sağlandı.
             */
            if (!existUserbasket)
            {
                return new GenericIdDto(request.Id);
            }

            this._context.Remove(existUserbasket);
            await this._context.SaveChangesAsync(cancellationToken);

            return new GenericIdDto(request.Id);
        }
    }
}
