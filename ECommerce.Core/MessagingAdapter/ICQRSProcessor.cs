namespace ECommerce.Core.MessagingAdapter
{
    public interface ICQRSProcessor
    {
        Task<TResponse> SendAsync<TResponse>(IBaseQuery<TResponse> query, CancellationToken cancellationToken = default);
        Task<TResponse> SendAsync<TResponse>(IBaseCommand<TResponse> command, CancellationToken cancellationToken = default);
    }
}
