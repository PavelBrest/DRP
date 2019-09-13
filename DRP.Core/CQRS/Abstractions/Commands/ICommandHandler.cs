using MediatR;

namespace DRP.Core.CQRS.Abstractions.Commands
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit>
        where TCommand : ICommand
    {
    }
}
