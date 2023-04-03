using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Orders.GetOrder
{
    public class GetOrderQueryHandler : BaseQueryHandler<GetOrderQuery, GetOrderDto>
    {
        private readonly ApplicationDbContext _context;

        public GetOrderQueryHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<GetOrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await this._context.Set<Order>()
                .FirstOrDefaultAsync(x =>
                    x.OrderNumber == request.OrderNumber,
                    cancellationToken)
                ?? throw new KeyNotFoundException("İlgili sipariş kaydı bulunamadı");

            return new GetOrderDto()
            {
                OrderNumber = order.OrderNumber,
                Note = order.Note,
                Status = order.Status,
                UserId = order.UserId
            };
        }
    }
}
