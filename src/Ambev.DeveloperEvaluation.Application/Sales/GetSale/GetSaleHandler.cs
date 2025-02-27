using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

public class GetSaleHandler(ISaleRepository repository, IEventPublisher eventPublisher, IMapper mapper) : IRequestHandler<GetSaleQuery, GetSaleResult>
{
    public async Task<GetSaleResult> Handle(GetSaleQuery request, CancellationToken cancellationToken)
    {
        var sale = await repository.GetSale(request.Id);
                
        var dto = mapper.Map<SaleDTO>(sale);

        return new GetSaleResult()
        {
            Id = dto.Id,
            Customer = dto.Customer,
            Branch = dto.Branch,
            Items = dto.Items,
            TotalAmount = dto.TotalAmount,
        };
    }
}
