using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository(DefaultContext context) : ISaleRepository
{
    public async Task DeleteSale(Guid id)
    {
        var sale = await context.Sales.FindAsync(id);
        if (sale != null)
        {
            context.Sales.Remove(sale);
            await context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException($"Sale with ID {id} not found.");
        }
    }

    public async Task<IEnumerable<Sale>> GetAll()
    {
        return await context.Sales.ToListAsync();
    }

    public async Task<Sale?> GetSale(Guid id)
    {
        return await context.Sales.FirstOrDefaultAsync(s => s.Id.Equals(id));
    }

    public async Task SaveSale(Sale sale)
    {
        await context.Sales.AddAsync(sale);
    }

    public async Task UpdateSale(Guid id, Sale sale)
    {
        var saleFromDb = await context.Sales.FirstOrDefaultAsync(s => s.Id.Equals(id));

        if (saleFromDb != null) {
            saleFromDb = sale;
        }
        await context.SaveChangesAsync();
    }
}
