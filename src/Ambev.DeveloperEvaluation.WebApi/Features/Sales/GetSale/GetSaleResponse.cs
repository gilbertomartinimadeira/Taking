using Ambev.DeveloperEvaluation.Application.DTOs;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleResponse
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Branch { get; set; }

        public IEnumerable<SaleItemDTO> Items { get; set; } = [];
    }
}
