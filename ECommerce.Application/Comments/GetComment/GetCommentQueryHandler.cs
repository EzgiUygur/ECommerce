using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Comments.GetComment
{
    public class GetCommentQueryHandler : BaseQueryHandler<GetCommentQuery, GetCommentDto>
    {
        private readonly ApplicationDbContext _context;

        public GetCommentQueryHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<GetCommentDto> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var comment = await this._context.Set<Comment>()
                .FirstOrDefaultAsync(x =>
                    x.Id == request.Id,
                    cancellationToken)
                ?? throw new KeyNotFoundException("İlgili yorum bulunamadı");

            return new GetCommentDto()
            {
                Id = comment.Id,
                UserId = comment.UserId,
                ProductId = comment.ProductId,
                Message = comment.Message
            };
        }
    }
}
