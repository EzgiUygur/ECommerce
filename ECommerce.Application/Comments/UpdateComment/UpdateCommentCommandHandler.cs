using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;
using ECommerce.Domain.Context;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Comments.UpdateComment
{
    public class UpdateCommentCommandHandler : BaseCommandHandler<UpdateCommentCommand, GenericIdDto>
    {
        private readonly ApplicationDbContext _context;

        public UpdateCommentCommandHandler(ApplicationDbContext context)
        {
            this._context = context;
        }

        public override async Task<GenericIdDto> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await this._context.Set<Comment>()
                .FirstOrDefaultAsync(x =>
                    x.Id == request.Id,
                    cancellationToken)
                ?? throw new KeyNotFoundException("İlgili yorum bulunamadı");

            comment.Message = request.Message;
            comment.UpdatedDate = DateTime.UtcNow;

            this._context.Update(comment);
            await this._context.SaveChangesAsync(cancellationToken);

            return new GenericIdDto(comment.Id);
        }
    }
}
