namespace Ambev.DeveloperEvaluation.Application.DTOs;
public class SaleDTO
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Customer { get; set; }
    public decimal TotalAmount { get; set; }
    public string Branch { get;  set; }
    public bool IsCancelled { get; set; }
    public List<SaleItemDTO> Items { get; set; }
}
