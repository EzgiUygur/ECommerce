using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Products.GetProducts
{
    public class GetProductsQueryHandler : BaseQueryHandler<GetProductsQuery, List<GetProductDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetProductsQueryHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<List<GetProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var query = this._context.Set<Product>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(x => x.Name == request.Name);
            }

            return await query.Select(x => new GetProductDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                ImageUrl = x.ImageUrl
            }).ToListAsync(cancellationToken);
        }
    }
}
