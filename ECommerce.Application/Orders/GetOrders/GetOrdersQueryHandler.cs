using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Orders.GetOrders
{
    public class GetOrdersQueryHandler : BaseQueryHandler<GetOrdersQuery, List<GetOrderDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetOrdersQueryHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<List<GetOrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var query = this._context.Set<Order>().AsQueryable();

            if (request.UserId != null)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }

            return await query.Select(x => new GetOrderDto()
            {
                OrderNumber = x.OrderNumber,
                Note = x.Note,
                Status = x.Status,
                UserId = x.UserId
            }).ToListAsync(cancellationToken);
        }
    }
}
