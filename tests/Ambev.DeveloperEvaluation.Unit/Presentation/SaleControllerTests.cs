using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Presentation.Controllers;

public class SalesControllerTests
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly SalesController _controller;

    public SalesControllerTests()
    {
        _mediator = Substitute.For<IMediator>();
        _mapper = Substitute.For<IMapper>();
        _controller = new SalesController(_mediator, _mapper);
    }

    [Fact]
    public async Task GetSaleById_ValidRequest_ReturnsOkResult()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var request = new GetSaleRequest
        {
            Customer = "Gilberto",
            Branch = "Test",
            Id = Guid.NewGuid()
        };
        var query = new GetSaleQuery { Id = request.Id };
        _mapper.Map<GetSaleQuery>(request).Returns(query);

        var domainResult = new GetSaleResult
        {
            Id = Guid.NewGuid()
        };
        _mediator.Send(query, cancellationToken).Returns(Task.FromResult(domainResult));

        var response = new GetSaleResponse
        {
            Sale = new SaleDTO() { Customer = request.Customer, Branch = request.Branch, Date = DateTime.Now }
        };
        _mapper.Map<GetSaleResponse>(domainResult).Returns(response);

        // Act
        var actionResult = await _controller.GetSaleById(request.Id, cancellationToken);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(actionResult);
        Assert.Equal(response, okResult.Value);
    }

    [Fact]
    public async Task GetSaleById_InvalidRequest_ReturnsBadRequest()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var invalidRequest = Guid.Empty;

        // Act
        var actionResult = await _controller.GetSaleById(invalidRequest, cancellationToken);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult);
        Assert.NotNull(badRequestResult.Value);
    }

    [Fact]
    public async Task GetSaleById_ResponseIsNull_ReturnsNotFound()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var request = new GetSaleRequest
        {
            Customer = "Gilberto",
            Branch = "Test",
            Id = Guid.NewGuid()
        };

        var query = new GetSaleQuery { Id = request.Id };
        _mapper.Map<GetSaleQuery>(request).Returns(query);

        var domainResult = new GetSaleResult();


        _mediator.Send(query, cancellationToken).Returns(Task.FromResult(domainResult));

       _mapper.Map<GetSaleResponse>(domainResult).Returns((GetSaleResponse)null);

        // Act
        var actionResult = await _controller.GetSaleById(request.Id, cancellationToken);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(actionResult);
        Assert.Null(notFoundResult.Value);
    }
}
