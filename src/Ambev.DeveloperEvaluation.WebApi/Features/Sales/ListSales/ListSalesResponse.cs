using Ambev.DeveloperEvaluation.Application.DTOs;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales
{
    public class ListSalesResponse
    {
        public List<SaleDTO> Sale { get; set; } = [];
    }
}
