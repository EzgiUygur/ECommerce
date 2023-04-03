using ECommerce.Core.Validation;
using MediatR.Pipeline;

namespace ECommerce.Core.MessagingAdapter
{
    public class CQRSValidationProcessor<TMessage> : IRequestPreProcessor<TMessage>
    {
        private readonly IEnumerable<IBaseValidator<TMessage>> _validators;

        public CQRSValidationProcessor(IEnumerable<IBaseValidator<TMessage>> validators)
        {
            this._validators = validators;
        }

        public Task Process(TMessage request, CancellationToken cancellationToken)
        {
            var errors = this._validators
                .Select(x => x.Validate(request))
                .SelectMany(x => x.Errors)
                .Where(error => error != null)
                .ToList();

            // Exception Middleware yazılınca modeli değiştir.asdasdasdasd
            if (errors.Any())
            {
                throw new Exception(errors.FirstOrDefault()?.ErrorMessage);
            }

            return Task.CompletedTask;
        }
    }
}
