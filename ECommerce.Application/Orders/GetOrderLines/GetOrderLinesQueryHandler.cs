using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Orders.GetOrderLines
{
    public class GetOrderLinesQueryHandler : BaseQueryHandler<GetOrderLinesQuery, List<GetOrderLineDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetOrderLinesQueryHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<List<GetOrderLineDto>> Handle(GetOrderLinesQuery request, CancellationToken cancellationToken)
        {
            var order = await this._context.Set<Order>()
                .FirstOrDefaultAsync(x =>
                    x.OrderNumber == request.OrderNumber,
                    cancellationToken)
                ?? throw new KeyNotFoundException("İlgili sipariş kaydı bulunamadı");

            return await this._context.Set<OrderLine>()
                .Where(x => x.OrderId == order.Id)
                .Join(
                    this._context.Set<Product>(),
                    x => x.ProductId,
                    y => y.Id,
                    (x, y) => new { x, y })
                .Select(a => new GetOrderLineDto()
                {
                    OrderNumber = order.OrderNumber,
                    ProductId = a.x.ProductId,
                    Quantity = a.x.Quantity,
                    TotalPrice = a.x.TotalPrice,
                    ProductName = a.y.Name,
                    UnitPrice = a.y.Price
                }).ToListAsync(cancellationToken);
        }
    }
}
