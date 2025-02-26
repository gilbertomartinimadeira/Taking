using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

public class ListSalesHandler(ISaleRepository repository, IEventPublisher eventPublisher, IMapper mapper) : IRequestHandler<ListSalesQuery, ListSalesResult>
{
    public async Task<ListSalesResult> Handle(ListSalesQuery request, CancellationToken cancellationToken)
    {
        var salesQuery = await repository.GetAll();

        var salesLinq = from sale in salesQuery
                        where sale != null && !sale.IsCancelled select sale;  
                       
        if(!string.IsNullOrWhiteSpace(request.Branch)) salesLinq = from sale in salesLinq where sale.Branch == request.Branch select sale;
        if (!string.IsNullOrWhiteSpace(request.Customer)) salesLinq = from sale in salesLinq where sale.Customer == request.Customer select sale;

        var sales = salesLinq.ToList();

        var dto = mapper.Map<List<SaleDTO>>(sales);

        return new ListSalesResult() { Sales = dto };

    }
}
