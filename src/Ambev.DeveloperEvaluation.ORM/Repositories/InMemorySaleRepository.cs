using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class InMemorySaleRepository : ISaleRepository
{
    private static readonly List<Sale> _sales;

    static InMemorySaleRepository()
    {
        _sales = new List<Sale>
        {
            new("John Doe", "NY", []),
            new("Jane Smith", "LA", []),
            new("Alice Brown", "TX", []),
            new("Bob White", "FL", []),
            new("Charlie Green", "IL", []),
            new("David Black", "WA", []),
            new("Emma Blue", "CO", []),
            new("Frank Yellow", "NV", []),
            new("Grace Purple", "GA", []),
            new("Hank Orange", "MI", [])
        };

        _sales.ForEach(s => {
            var items = MockItems(s.Id);

            foreach(var item in items)
            {
                s.AddItem(item);
            }                       
        });
    }

    public Task<IEnumerable<Sale>> GetAll()
    {
        return Task.FromResult(_sales.Where(s => !s.IsCancelled).AsEnumerable());
    }
    public Task<Sale?> GetSale(Guid id)
    {
        var sale = _sales.FirstOrDefault(s => s.Id == id);
        return Task.FromResult(sale);
    }

    public Task SaveSale(Sale sale)
    {
        _sales.Add(sale);
        return Task.CompletedTask;
    }

    public Task UpdateSale(Guid id, Sale sale)
    {
        var existingSale = _sales.FirstOrDefault(s => s.Id == id);

        if (existingSale != null)
        {
            existingSale = new Sale(sale.Customer, sale.Branch, sale.Items);
        }

        return Task.CompletedTask;
    }

    public Task DeleteSale(Guid id)
    {
        var sale = _sales.FirstOrDefault(s => s.Id == id);
       
        sale?.Cancel();

        return Task.CompletedTask;
    }

    private static List<SaleItem> MockItems(Guid saleId)
    {
        return new List<SaleItem>
        {
            new SaleItem(saleId, "Product A", 2, 69m),
            new SaleItem(saleId, "Product B", 5, 24m),
            new SaleItem(saleId, "Product C", 1, 171m),
            new SaleItem(saleId, "Product D", 1, 22m)
        };
    }
}
