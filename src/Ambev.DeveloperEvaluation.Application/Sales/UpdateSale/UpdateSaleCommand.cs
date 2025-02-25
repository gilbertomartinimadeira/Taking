
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleCommand : IRequest<Guid>
    {
        public Guid SaleId { get; internal set; }
        public string? Customer { get; internal set; }
        public string? Branch { get; internal set; }
        public IEnumerable<SaleItem> Items { get; internal set; }
    }
}