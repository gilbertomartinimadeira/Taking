using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
            RuleFor(sale => sale.Customer).NotEmpty().Length(3, 50);
            RuleFor(sale => sale.Branch).NotEmpty().Length(3, 50);
            RuleFor(sale => sale.Items).NotEmpty();
        }
    }
}
