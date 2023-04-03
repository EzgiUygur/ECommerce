using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Orders.InTransitOrder
{
    public class InTransitOrderCommandHandler : BaseCommandHandler<InTransitOrderCommand, OrderDto>
    {
        private readonly ApplicationDbContext _context;

        public InTransitOrderCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<OrderDto> Handle(InTransitOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await this._context.Set<Order>()
               .FirstOrDefaultAsync(x =>
                   x.OrderNumber == request.OrderNumber,
                   cancellationToken)
               ?? throw new KeyNotFoundException("İlgili sipariş kaydı bulunamadı");

            if (order.Status != OrderStatus.InProgress)
            {
                throw new Exception("Sipariş statüsü uygun değil");
            }

            order.Status = OrderStatus.InTransit;
            order.UpdatedDate = DateTime.UtcNow;

            this._context.Update(order);
            await this._context.SaveChangesAsync(cancellationToken);

            return new OrderDto(order.OrderNumber);
        }
    }
}
