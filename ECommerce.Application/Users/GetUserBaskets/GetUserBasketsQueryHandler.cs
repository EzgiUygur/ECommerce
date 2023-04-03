using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Users.GetUserBaskets
{
    public class GetUserBasketsQueryHandler : BaseQueryHandler<GetUserBasketsQuery, List<GetUserBasketDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetUserBasketsQueryHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<List<GetUserBasketDto>> Handle(GetUserBasketsQuery request, CancellationToken cancellationToken)
        {
            var user = await this._context.Set<User>()
                .FirstOrDefaultAsync(x =>
                    x.Id == request.Id,
                    cancellationToken)
                ?? throw new KeyNotFoundException("İlgili kullanıcı kaydı bulunamadı");

            return await this._context.Set<UserBasket>()
                .Where(x => x.Id == request.Id)
                .Join(
                    this._context.Set<Product>(),
                    x => x.ProductId,
                    y => y.Id,
                    (x, y) => new { x, y })
                .Select(a => new GetUserBasketDto()
                {
                    Id = a.x.Id,
                    ProductId = a.x.ProductId,
                    Quantity = a.x.Quantity,
                    ProductName = a.y.Name,
                    UnitPrice = a.y.Price
                }).ToListAsync(cancellationToken);
        }
    }
}
