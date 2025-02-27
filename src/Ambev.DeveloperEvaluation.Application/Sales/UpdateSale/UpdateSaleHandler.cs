using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler(ISaleRepository repository, IEventPublisher _eventPublisher) : IRequestHandler<UpdateSaleCommand, Guid>
{        
    public async Task<Guid> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await repository.GetSale(request.SaleId);

        if (sale == null)
            throw new Exception("Sale not found.");

        var updatedItems = request.Items.Select(i => new SaleItem(sale.Id, i.Product, i.Quantity, i.UnitPrice)).ToList();
        sale.Update(request.Customer, request.Branch, updatedItems);

        await repository.UpdateSale(sale);

        await _eventPublisher.Publish(new SaleModifiedEvent(sale));

        return sale.Id;
    }
}
