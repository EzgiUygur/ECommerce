using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Comments.GetComments
{
    public class GetCommentsQueryHandler : BaseQueryHandler<GetCommentsQuery, List<GetCommentDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetCommentsQueryHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<List<GetCommentDto>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var query = this._context.Set<Comment>().AsQueryable();

            if (request.UserId != null)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }

            if (request.ProductId != null)
            {
                query = query.Where(x => x.ProductId == request.ProductId);
            }

            return await query.Select(x => new GetCommentDto()
            {
                Id = x.Id,
                UserId = x.UserId,
                ProductId = x.ProductId,
                Message = x.Message
            }).ToListAsync(cancellationToken);
        }
    }
}
