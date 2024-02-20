using MediatR;

namespace Catalog.UseCases.Common.Abstractions.CQRS;

internal interface IQuery<TReturn> : IRequest<TReturn>
{
}
