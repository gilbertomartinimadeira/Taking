using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Application.Interfaces;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events.Sales;
using Ambev.DeveloperEvaluation.ORM;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateSaleHandlerTests
    {
        private readonly DefaultContext _context;
        private readonly IEventPublisher _eventPublisher = Substitute.For<IEventPublisher>();
        private readonly IMapper _mapper = Substitute.For<IMapper>();
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {           
            var options = new DbContextOptionsBuilder<DefaultContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new DefaultContext(options);

            _eventPublisher = Substitute.For<IEventPublisher>();
           
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaleItemDTO, SaleItem>();
            });

            _mapper = config.CreateMapper();

            _handler = new CreateSaleHandler(_context, _eventPublisher, _mapper);
        }

        [Fact]
        public async Task Handle_ShouldCreateSaleAndPublishEvent()
        {
            // Arrange
            var saleItemsDTO = new List<SaleItemDTO>
            {
                new SaleItemDTO { Product = "Product1", Quantity = 5, UnitPrice = 10.0m }
            };

            var request = new CreateSaleCommand { Customer = "John Doe", Branch = "Branch1", Items = saleItemsDTO };

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John Doe", result.Customer);
            Assert.Equal("Branch1", result.Branch);
            Assert.Single(result.Items);

            // Verify event publishing
            await _eventPublisher.Received(1).Publish(Arg.Any<SaleCreatedEvent>());
        }
    }
}
