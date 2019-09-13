using DRP.Core.CQRS.Abstractions.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DRP.Core.CQRS
{
    sealed class CommandBus : ICommandBus
    {
        private readonly IMediator _mediator;

        public CommandBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Send<TCommand>(TCommand command, CancellationToken token = default) 
            where TCommand : ICommand
        {
            return _mediator.Send(command, token);
        }
    }
}
