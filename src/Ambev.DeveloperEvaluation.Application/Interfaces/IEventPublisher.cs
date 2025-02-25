using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Application.Interfaces
{
    public interface IEventPublisher
    {
        Task Publish<T>(T eventParam) where T : IEvent;
    }
}
