using ECommerce.Core.MessagingAdapter.Queries;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Comments.GetCommentCount
{
    public class GetCommentCountQueryHandler : BaseQueryHandler<GetCommentCountQuery, int>
    {
        private readonly ApplicationDbContext _context;

        public GetCommentCountQueryHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<int> Handle(GetCommentCountQuery request, CancellationToken cancellationToken)
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

            return await query.CountAsync(cancellationToken);
        }
    }
}
