using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Events.Sales;
using Ambev.DeveloperEvaluation.ORM;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelSaleCommandHandler : IRequestHandler<CancelSaleCommand, bool>
    {
        private readonly DefaultContext _context;
        private readonly IEventPublisher _eventPublisher;

        public CancelSaleCommandHandler(DefaultContext context, IEventPublisher eventPublisher)
        {
            _context = context;
            _eventPublisher = eventPublisher;
        }

        public async Task<bool> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _context.Sales.FindAsync(request.SaleId) ?? throw new Exception("Sale not found");

            sale.Cancel();

            await _context.SaveChangesAsync(cancellationToken);
            _eventPublisher.Publish(new SaleCancelledEvent(sale));

            return true;
        }
    }
}
