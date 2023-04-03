using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Products.InsertProduct
{
    public class InsertProductCommandHandler : BaseCommandHandler<InsertProductCommand, GenericIdDto>
    {
        private readonly ApplicationDbContext _context;

        public InsertProductCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<GenericIdDto> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            var existProduct = await this._context.Set<Product>()
                .FirstOrDefaultAsync(x =>
                    x.Name == request.Name,
                    cancellationToken);

            /*
             * RESTful gereği idempotency sağlandı.
             */
            if (existProduct != null)
            {
                return new GenericIdDto(existProduct.Id);
            }

            var product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = (int)request.Stock,
                ImageUrl = request.ImageUrl
            };

            await this._context.AddAsync(product, cancellationToken);
            await this._context.SaveChangesAsync(cancellationToken);

            return new GenericIdDto(product.Id);
        }
    }
}
