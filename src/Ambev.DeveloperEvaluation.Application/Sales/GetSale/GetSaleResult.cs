using Ambev.DeveloperEvaluation.Application.DTOs;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleResult
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string? Customer { get; set; }
    public decimal TotalAmount { get; set; }
    public string? Branch { get; set; }

    public IEnumerable<SaleItemDTO> Items { get; set; } = [];
}
