using FluentValidation;
using MediatR;
using Metafar.ATM.Application.Features;
using Metafar.ATM.Domain.Models;

namespace Metafar.ATM.Application.Validators
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, Response<TResponse>> where TRequest : notnull
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationBehavior(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task<Response<TResponse>> Handle(TRequest request, RequestHandlerDelegate<Response<TResponse>> next, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return ResponseService<TResponse>.GetResponseMultipleErrors(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            return await next();
        }
    }
}
