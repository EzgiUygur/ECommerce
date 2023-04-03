using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;

namespace ECommerce.Application.Comments.GetComment
{
    public class GetCommentQuery : BaseQuery<GetCommentDto>
    {
        public GetCommentQuery(long id)
        {
            this.Id = id;
        }

        public long Id { get; private set; }
    }
}
