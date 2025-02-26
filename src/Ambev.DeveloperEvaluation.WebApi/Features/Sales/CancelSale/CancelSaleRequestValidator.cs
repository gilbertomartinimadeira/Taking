using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CancelSaleRequestValidator : AbstractValidator<CancelSaleRequest>
    {
        public CancelSaleRequestValidator()
        {
            RuleFor(request => request.Id).NotEqual(Guid.Empty);           
        }
    }
}
