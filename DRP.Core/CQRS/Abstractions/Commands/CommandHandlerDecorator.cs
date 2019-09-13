using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DRP.Core.CQRS.Abstractions.Commands
{
    public abstract class CommandHandlerDecorator<TCommand>
        : IPipelineBehavior<TCommand, Unit>
        where TCommand : ICommand
    {
        public abstract Task<Unit> Handle(TCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<Unit> next);
    }
}
