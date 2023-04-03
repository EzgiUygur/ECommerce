using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Orders.InsertOrder
{
    public class InsertOrderCommandHandler : BaseCommandHandler<InsertOrderCommand, OrderDto>
    {
        private readonly ApplicationDbContext _context;

        public InsertOrderCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<OrderDto> Handle(InsertOrderCommand request, CancellationToken cancellationToken)
        {
            var existUser = await this._context.Set<User>()
               .AnyAsync(x =>
                   x.Id == request.UserId,
                   cancellationToken);

            if (!existUser)
            {
                throw new Exception("İlgili kullanıcı bulunamadı");
            }

            var order = new Order()
            {
                OrderNumber = Guid.NewGuid().ToString("N"),
                Status = OrderStatus.Placed,
                Note = request.Note,
                UserId = request.UserId,
                OrderLines = new List<OrderLine>()
            };

            foreach (var orderLine in request.OrderLines)
            {
                var product = await this._context.Set<Product>()
                   .FirstOrDefaultAsync(x =>
                       x.Id == orderLine.ProductId,
                       cancellationToken)
                   ?? throw new Exception("İlgili ürün bulunamadı");

                order.OrderLines.Add(new OrderLine()
                {
                    ProductId = orderLine.ProductId,
                    Quantity = (int)orderLine.Quantity,
                    TotalPrice = orderLine.Quantity * product.Price
                });
            }

            await this._context.AddAsync(order, cancellationToken);
            await this._context.SaveChangesAsync(cancellationToken);

            return new OrderDto(order.OrderNumber);
        }
    }
}
