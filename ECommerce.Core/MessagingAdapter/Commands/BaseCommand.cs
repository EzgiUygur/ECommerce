using MediatR;

namespace ECommerce.Core.MessagingAdapter.Commands
{
    public class BaseCommand<TResponse> : IBaseCommand<TResponse>
    {
    }
}
