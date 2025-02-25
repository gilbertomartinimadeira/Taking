using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales
{
    public class SaleCreatedEvent : IEvent
    {
        public Sale Sale { get; }
        public DateTime OccurredOn { get; set; }

        public SaleCreatedEvent(Sale sale)
        {
            Sale = sale;
        }
    }
}
