using MediatR;

namespace ECommerce.Core.MessagingAdapter
{
    public interface IBaseQuery<TResponse> : IRequest<TResponse>
    {
    }
}
