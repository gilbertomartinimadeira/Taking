using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(sale=> sale.Customer).NotEmpty().Length(3, 50);                       
            RuleFor(sale => sale.Branch).NotEmpty().Length(3, 50);
            RuleFor(sale => sale.Items).NotEmpty();
        }
    }
}
