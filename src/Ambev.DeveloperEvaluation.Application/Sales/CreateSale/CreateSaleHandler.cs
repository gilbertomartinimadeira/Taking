using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events.Sales;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler(ISaleRepository repository, IEventPublisher eventPublisher, IMapper mapper) : IRequestHandler<CreateSaleCommand, Sale>
    {
        public async Task<Sale> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var saleItems = mapper.Map<IEnumerable<SaleItem>>(request.Items);

            var sale = new Sale(request.Customer!, request.Branch!, saleItems);

            await repository.SaveSale(sale);           

            await eventPublisher.Publish(new SaleCreatedEvent(sale));

            return sale;
        }
    }
}
