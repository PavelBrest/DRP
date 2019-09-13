using System.Threading.Tasks;

namespace DRP.Core.CQRS.Abstractions.Events
{
    public interface IEventBus
    {
        Task Publish<TEvent>(TEvent @event)
            where TEvent : class, IEvent;
    }
}
