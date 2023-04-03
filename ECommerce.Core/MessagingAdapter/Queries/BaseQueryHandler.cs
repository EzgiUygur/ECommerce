namespace ECommerce.Core.MessagingAdapter.Queries
{
    public abstract class BaseQueryHandler<TRequest, TResponse> : IBaseQueryHandler<TRequest, TResponse>
        where TRequest : BaseQuery<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
