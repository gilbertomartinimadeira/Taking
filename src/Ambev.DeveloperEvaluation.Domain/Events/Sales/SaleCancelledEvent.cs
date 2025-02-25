using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales
{
    public class SaleCancelledEvent : IEvent
    {
        public Sale Sale { get; }
        public DateTime OccurredOn { get; set; }

        public SaleCancelledEvent(Sale sale)
        {
            Sale = sale;
        }
    }
}
