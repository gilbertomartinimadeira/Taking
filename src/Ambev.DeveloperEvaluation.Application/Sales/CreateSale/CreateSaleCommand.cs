using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<Sale>
    {
        public string? Customer { get; set; }
        public string? Branch { get; set; }
        public List<SaleItemDTO> Items { get; set; } = [];
    }
}
