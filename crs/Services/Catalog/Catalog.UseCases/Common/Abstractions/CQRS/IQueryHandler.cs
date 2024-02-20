using MediatR;

namespace Catalog.UseCases.Common.Abstractions.CQRS;

internal interface IQueryHandler<TQuery, TReturn> : IRequestHandler<TQuery, TReturn>
    where TQuery : IQuery<TReturn>
{
}
