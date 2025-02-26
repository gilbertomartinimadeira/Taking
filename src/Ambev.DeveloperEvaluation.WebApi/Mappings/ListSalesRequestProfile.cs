using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Application.Sales.ListSales;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class ListSalesRequestProfile : Profile
{
    public ListSalesRequestProfile()
    {
        CreateMap<ListSalesRequest, ListSalesQuery>();
        CreateMap<Sale, SaleDTO>();
    }
}
