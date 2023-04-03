using FluentValidation;

namespace ECommerce.Core.Validation
{
    // Inheritance wrapping
    public interface IBaseValidator : IValidator
    {
    }

    // Inheritance wrapping
    public interface IBaseValidator<T> : IBaseValidator, IValidator<T>
    {
    }

    // Inheritance wrapping
    public abstract class BaseValidator<T> : AbstractValidator<T>, IBaseValidator<T>
    {
    }
}
