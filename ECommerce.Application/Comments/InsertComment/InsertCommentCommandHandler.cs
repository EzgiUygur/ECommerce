using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Comments.InsertComment
{
    public class InsertCommentCommandHandler : BaseCommandHandler<InsertCommentCommand, GenericIdDto>
    {
        private readonly ApplicationDbContext _context;

        public InsertCommentCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<GenericIdDto> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
        {
            var existProduct = await this._context.Set<Product>()
               .AnyAsync(x =>
                   x.Id == request.ProductId,
                   cancellationToken);

            if (!existProduct)
            {
                throw new Exception("İlgili ürün bulunamadı");
            }

            var existUser = await this._context.Set<User>()
               .AnyAsync(x =>
                   x.Id == request.UserId,
                   cancellationToken);

            if (!existUser)
            {
                throw new Exception("İlgili kullanıcı bulunamadı");
            }

            var comment = new Comment()
            {
                UserId = request.UserId,
                ProductId = request.ProductId,
                Message = request.Message
            };

            await this._context.AddAsync(comment, cancellationToken);
            await this._context.SaveChangesAsync(cancellationToken);

            return new GenericIdDto(comment.Id);
        }
    }
}
