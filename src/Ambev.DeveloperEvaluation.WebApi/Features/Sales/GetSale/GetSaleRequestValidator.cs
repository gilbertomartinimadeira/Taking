using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
    {
        public GetSaleRequestValidator()
        {
            RuleFor(sale => sale.Id).NotEqual(Guid.Empty);           
        }
    }
}
