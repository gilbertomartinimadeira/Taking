using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;
public class ListSalesQuery : IRequest<ListSalesResult>
{
    public string? Customer { get; set; }
    public string? Branch { get; set; }
    public DateTime Date { get; set; }
}
