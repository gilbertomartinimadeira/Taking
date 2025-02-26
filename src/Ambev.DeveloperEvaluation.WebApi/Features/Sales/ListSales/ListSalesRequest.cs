namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales
{
    public class ListSalesRequest
    {       
        public string? Customer { get; set; }
        public string? Branch { get; set; }
        public DateTime? Date { get; set; }
    }
}
