using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events.Sales
{
    public class SaleModifiedEvent : IEvent
    {
        public Sale Sale { get; }
        public DateTime OccurredOn { get; set; }
        public SaleModifiedEvent(Sale sale)
        {
            Sale = sale;
        }
    }
}
