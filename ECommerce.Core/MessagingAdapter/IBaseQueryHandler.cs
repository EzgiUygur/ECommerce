using MediatR;

namespace ECommerce.Core.MessagingAdapter
{
    public interface IBaseQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IBaseQuery<TResponse>
    {
    }
}
