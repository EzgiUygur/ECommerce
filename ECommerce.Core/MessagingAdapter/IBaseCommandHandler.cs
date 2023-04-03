using MediatR;

namespace ECommerce.Core.MessagingAdapter
{
    public interface IBaseCommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IBaseCommand<TResponse>
    {
    }
}
