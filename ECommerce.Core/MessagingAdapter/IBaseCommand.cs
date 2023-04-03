using MediatR;

namespace ECommerce.Core.MessagingAdapter
{
    public interface IBaseCommand<TResult> : IRequest<TResult>
    {
    }
}
