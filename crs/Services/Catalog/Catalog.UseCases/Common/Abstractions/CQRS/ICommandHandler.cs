using MediatR;

namespace Catalog.UseCases.Common.Abstractions.CQRS;

internal interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}

internal interface ICommandHandler<TCommand, TReturn> : IRequestHandler<TCommand, TReturn>
    where TCommand : ICommand<TReturn>
{
}
