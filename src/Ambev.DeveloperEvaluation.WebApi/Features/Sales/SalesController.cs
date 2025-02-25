using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

[ApiController]
[Route("api/[controller]")]
public class SalesController(IMediator mediator, IMapper mapper) : BaseController
{

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateUserResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Sale>> CreateSale([FromBody]CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = mapper.Map<CreateSaleCommand>(request);
        var response = await mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = mapper.Map<CreateSaleResponse>(response)
        });
    }

    //[HttpPut("{saleId}")]
    //public async Task<ActionResult<Sale>> UpdateSale(Guid saleId, [FromBody] Sale updatedSale)
    //{
    //    var command = new UpdateSaleCommand(saleId, updatedSale);
    //    var updated = await _mediator.Send(command);

    //    return Ok(updated);
    //}

    //[HttpDelete("{saleId}")]
    //public async Task<ActionResult> CancelSale(Guid saleId)
    //{
    //    var command = new CancelSaleCommand(saleId);
    //    var result = await _mediator.Send(command);

    //    return result ? Ok() : NotFound();
    //}
}
