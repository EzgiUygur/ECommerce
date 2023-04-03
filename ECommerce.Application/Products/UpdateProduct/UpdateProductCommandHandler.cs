using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : BaseCommandHandler<UpdateProductCommand, GenericIdDto>
    {
        private readonly ApplicationDbContext _context;

        public UpdateProductCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<GenericIdDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await this._context.Set<Product>()
                .FirstOrDefaultAsync(x =>
                    x.Id == request.Id,
                    cancellationToken)
                ?? throw new KeyNotFoundException("İlgili ürün bulunamadı");

            var existProduct = await this._context.Set<Product>()
                .AnyAsync(x =>
                    x.Name == request.Name,
                    cancellationToken);

            if (existProduct)
            {
                throw new Exception("Aynı isimle ürün bulunuyor.");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Stock = request.Stock;
            product.Price = request.Price;
            product.ImageUrl = request.ImageUrl;

            this._context.Update(product);
            await this._context.SaveChangesAsync(cancellationToken);

            return new GenericIdDto(product.Id);
        }
    }
}
