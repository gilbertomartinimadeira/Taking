using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository
{
    Task SaveSale(Sale sale);
    Task<Sale?> GetSale(Guid id);
    Task<IEnumerable<Sale>> GetAll();
    Task UpdateSale(Sale sale);
    Task DeleteSale(Guid id);

}
