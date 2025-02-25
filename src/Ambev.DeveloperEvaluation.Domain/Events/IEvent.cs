namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public interface IEvent {
        DateTime OccurredOn { get; set; }
    }
}
