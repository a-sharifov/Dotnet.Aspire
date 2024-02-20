using MediatR;

namespace Catalog.UseCases.Common.Abstractions.CQRS;

internal interface ICommand : IRequest
{
}

internal interface ICommand<TReturn> : IRequest<TReturn>
{
}
