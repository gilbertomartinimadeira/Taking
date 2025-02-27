using Xunit;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class SaleTests
{
    [Fact]
    public void CreateSale_WithValidItems_CalculatesTotalCorrectly()
    {
        // Arrange
        var saleId = Guid.NewGuid();
        var items = new List<SaleItem>
        {
            new(saleId, "Product A", 2, 10m),
            new(saleId, "Product B", 4, 5m)
        };

        // Act
        var sale = new Sale("Gilberto", "Test", items);

        // Assert
        Assert.Equal("Gilberto", sale.Customer);
        Assert.Equal("Test", sale.Branch);
        Assert.Equal(2, sale.Items.Count);
        Assert.Equal(38m, sale.TotalAmount); // 20 + 18 = 38.
    }

    [Fact]
    public void AddItem_WithQuantityOverLimit_ThrowsException()
    {
        // Arrange
        var sale = new Sale("Gilberto", "Test", new List<SaleItem>());
        var saleId = Guid.NewGuid();
        var item = new SaleItem(saleId, "Product A", 21, 10m);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => sale.AddItem(item));
    }

    [Fact]
    public void AddItem_AppliesCorrectDiscountBasedOnQuantity()
    {
        // Arrange
        var sale = new Sale("Gilberto", "Test", new List<SaleItem>());
        var saleId = Guid.NewGuid();

        var item1 = new SaleItem(saleId, "Product A", 10, 10m);
        sale.AddItem(item1);
        Assert.Equal(80m, item1.Total);

        var item2 = new SaleItem(saleId, "Product B", 4, 10m);
        sale.AddItem(item2);
        Assert.Equal(36m, item2.Total);

        Assert.Equal(80m + 36m, sale.TotalAmount);
    }

    [Fact]
    public void CancelSale_SetsIsCancelledAndPreventsMultipleCancels()
    {
        // Arrange
        var sale = new Sale("Gilberto", "Test", new List<SaleItem>());

        // Act
        sale.Cancel();

        // Assert
        Assert.True(sale.IsCancelled);       
        Assert.Throws<InvalidOperationException>(() => sale.Cancel());
    }

    [Fact]
    public void UpdateSale_AddsNewItemsAndUpdatesTotal()
    {
        // Arrange
        var saleId = Guid.NewGuid();

        var initialItems = new List<SaleItem>
        {
            new SaleItem(saleId, "Product A", 2, 10m)
        };
        var sale = new Sale("Gilberto", "Test", initialItems);

        var newItems = new List<SaleItem>
        {
            new SaleItem(saleId, "Product B", 4, 5m)
        };

        // Act
        sale.Update(null, null, newItems);

        // Assert
        Assert.Equal(2, sale.Items.Count);
        Assert.Equal(38m, sale.TotalAmount);
    }
}
