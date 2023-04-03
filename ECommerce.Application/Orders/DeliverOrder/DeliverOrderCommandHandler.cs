using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Orders.DeliverOrder
{
    public class DeliverOrderCommandHandler : BaseCommandHandler<DeliverOrderCommand, OrderDto>
    {
        private readonly ApplicationDbContext _context;

        public DeliverOrderCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<OrderDto> Handle(DeliverOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await this._context.Set<Order>()
               .FirstOrDefaultAsync(x =>
                   x.OrderNumber == request.OrderNumber,
                   cancellationToken)
               ?? throw new KeyNotFoundException("İlgili sipariş kaydı bulunamadı");

            if (order.Status != OrderStatus.InTransit)
            {
                throw new Exception("Sipariş statüsü uygun değil");
            }

            order.Status = OrderStatus.Delivered;
            order.UpdatedDate = DateTime.UtcNow;

            this._context.Update(order);
            await this._context.SaveChangesAsync(cancellationToken);

            return new OrderDto(order.OrderNumber);
        }
    }
}
