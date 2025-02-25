namespace Ambev.DeveloperEvaluation.Application.DTOs
{
    public class SaleItemDTO
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
