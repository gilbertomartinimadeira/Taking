namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleRequest
    {
        public Guid Id { get; set; }
        public string? Customer { get; set; }
        public string? Branch { get; set; }
        public DateTime Date { get; set; }
    }
}
