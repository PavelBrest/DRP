using DRP.Core.CQRS.Abstractions.Events;
using MediatR;
using System.Threading.Tasks;

namespace DRP.Core.CQRS
{
    sealed class EventBus : IEventBus
    {
        private readonly IMediator _mediator;

        public EventBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        Task IEventBus.Publish<TEvent>(TEvent @event)
        {
            return _mediator.Publish(@event);
        }
    }
}
