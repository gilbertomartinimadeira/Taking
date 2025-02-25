using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events.Sales;
using Ambev.DeveloperEvaluation.ORM;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, Guid>
    {
        private readonly DefaultContext _context;
        private readonly IEventPublisher _eventPublisher;

        public UpdateSaleHandler(DefaultContext context, IEventPublisher eventPublisher)
        {
            _context = context;
            _eventPublisher = eventPublisher;
        }

        public async Task<Guid> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _context.Sales.FindAsync(request.SaleId);
            if (sale == null)
                throw new Exception("Sale not found.");

            var updatedItems = request.Items.Select(i => new SaleItem(sale.Id, i.Product, i.Quantity, i.UnitPrice)).ToList();
            sale.Update(request.Customer, request.Branch, updatedItems);

            await _context.SaveChangesAsync(cancellationToken);

            await _eventPublisher.Publish(new SaleModifiedEvent(sale));

            return sale.Id;
        }
    }
}
