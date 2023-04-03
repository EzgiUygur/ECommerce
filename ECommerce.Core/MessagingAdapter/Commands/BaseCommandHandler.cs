namespace ECommerce.Core.MessagingAdapter.Commands
{
    public abstract class BaseCommandHandler<TRequest, TResponse> : IBaseCommandHandler<TRequest, TResponse>
        where TRequest : BaseCommand<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
