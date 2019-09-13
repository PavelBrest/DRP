using MediatR;

namespace DRP.Core.CQRS.Abstractions.Events
{
    interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
        where TEvent : class, IEvent
    { }
}
