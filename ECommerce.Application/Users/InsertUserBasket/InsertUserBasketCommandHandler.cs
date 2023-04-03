using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Users.InsertUserBasket
{
    public class InsertUserBasketCommandHandler : BaseCommandHandler<InsertUserBasketCommand, GenericIdDto>
    {
        private readonly ApplicationDbContext _context;

        public InsertUserBasketCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<GenericIdDto> Handle(InsertUserBasketCommand request, CancellationToken cancellationToken)
        {
            var existUser = await this._context.Set<User>()
               .AnyAsync(x =>
                   x.Id == request.UserId,
                   cancellationToken);

            if (!existUser)
            {
                throw new Exception("İlgili kullanıcı bulunamadı");
            }

            var existProduct = await this._context.Set<Product>()
               .AnyAsync(x =>
                   x.Id == request.UserId,
                   cancellationToken);

            if (!existProduct)
            {
                throw new Exception("İlgili ürün kaydı bulunamadı");
            }

            var userBasket = new UserBasket()
            {
                UserId = request.UserId,
                ProductId = request.ProductId,
                Quantity = (int)request.Quantity
            };

            await this._context.AddAsync(userBasket, cancellationToken);
            await this._context.SaveChangesAsync(cancellationToken);

            return new GenericIdDto(userBasket.Id);
        }
    }
}
