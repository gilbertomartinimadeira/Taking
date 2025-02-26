using Ambev.DeveloperEvaluation.Application.DTOs;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequest
    {
        public Guid SaleId { get; set; }
        public string? Customer { get; set; }
        public string? Branch { get; set; }
        public IEnumerable<SaleItemDTO> Items { get; set; } = [];
    }
}
