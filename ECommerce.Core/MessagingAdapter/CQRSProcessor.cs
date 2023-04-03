using MediatR;

namespace ECommerce.Core.MessagingAdapter
{
    // Adapter Design Pattern // Wrapping with adapter pattern
    public class CQRSProcessor : ICQRSProcessor
    {
        private readonly IMediator _mediator;

        public CQRSProcessor(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public async Task<TResponse> SendAsync<TResponse>(
            IBaseQuery<TResponse> query,
            CancellationToken cancellationToken = default)
        {
            return await this._mediator.Send(query, cancellationToken);
        }

        public async Task<TResponse> SendAsync<TResponse>(
            IBaseCommand<TResponse> command,
            CancellationToken cancellationToken = default)
        {
            return await this._mediator.Send(command, cancellationToken);
        }
    }
}
