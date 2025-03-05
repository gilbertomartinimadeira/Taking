using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Events;
using Rebus.Bus;

namespace Ambev.DeveloperEvaluation.Infrastructure.EventPublishing
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IBus _bus;

        public EventPublisher(IBus bus)
        {
            _bus = bus;
        }

        public async Task Publish<T>(T eventParam) where T : IEvent
        {
            await _bus.Publish(eventParam);
        }
    }
}