

using ErrorOr;
using FluentValidation;
using Order.Framework.Core.Bus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Diet.Framework.Core.Bus;
using Diet.Framework.Core.Errors;

namespace Order.Framework.Core.Decorator;

 

public class ValidationQueryHandlerDecorator<TQuery, TQueryResult>
     : IQueryHandler<TQuery, TQueryResult>
       where TQuery : IQuery
       where TQueryResult : IQueryResult
{
    IServiceProvider serviceProvider;
    private readonly IQueryHandler<TQuery, TQueryResult> _handler;
    private IValidator<TQuery> _validators;

    public ValidationQueryHandlerDecorator(
        IQueryHandler<TQuery, TQueryResult> handler,
        IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        _handler = handler;
        _validators = serviceProvider.GetService<IValidator<TQuery>>()!;
    }

    public virtual async Task<ErrorOr<TQueryResult>> Handle(TQuery Query)
    {
        var validationResult = await _validators.ValidateAsync(Query);
        if (validationResult.IsValid && validationResult is not null)
        {
            var handler = new LoggerQueryHandlerDecorator<TQuery, TQueryResult>(_handler, this.serviceProvider);
            if (handler is not null)
            {
                return await handler.Handle(Query);
            }
        }

        var erorr = validationResult!.Errors
            .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage));
        erorr.Add(BusErrors.Query.IValidationQueryHandlerIsFalse(Query));

        return erorr;
    }
}


