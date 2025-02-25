using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public string? Customer { get; set; }
        public string? Branch { get; set; }
        public IEnumerable<SaleItemDTO> Items { get; set; } = [];
    }
}
