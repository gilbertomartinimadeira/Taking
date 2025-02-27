using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Events.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelSaleCommandHandler(ISaleRepository repository, IEventPublisher eventPublisher) : IRequestHandler<CancelSaleCommand, bool>
    {
        public async Task<bool> Handle(CancelSaleCommand command, CancellationToken cancellationToken)
        {
            try
            {              
                var sale = await repository.GetSale(command.Id) ?? throw new Exception("Sale not found");
                await repository.DeleteSale(command.Id);
                await eventPublisher.Publish(new SaleCancelledEvent(sale));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
                        
            return true;
        }
    }
}
