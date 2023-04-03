using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Products.GetProduct
{
    public class GetProductQueryHandler : BaseQueryHandler<GetProductQuery, GetProductDto>
    {
        private readonly ApplicationDbContext _context;

        public GetProductQueryHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<GetProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await this._context.Set<Product>()
                .FirstOrDefaultAsync(x =>
                    x.Id == request.Id,
                    cancellationToken)
                ?? throw new KeyNotFoundException("İlgili ürün bulunamadı");

            return new GetProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                ImageUrl = product.ImageUrl
            };
        }
    }
}
