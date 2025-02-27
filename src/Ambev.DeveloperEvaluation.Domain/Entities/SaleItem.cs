namespace Ambev.DeveloperEvaluation.Domain.Entities;
public class SaleItem
{
    public int ExternalId { get; set; }
    public Guid Id { get; private set; }
    public Guid SaleId { get; private set; }  
    public Sale Sale { get; private set; }   
    public string Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Discount { get; private set; }  
    public decimal Total { get; private set; }     

    public SaleItem() { } // Required for EF Core

    public SaleItem(Guid saleId, string product, int quantity, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(product))
            throw new ArgumentException("Product is required");

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero");

        if (unitPrice <= 0)
            throw new ArgumentException("Unit price must be greater than zero");

        Id = Guid.NewGuid();
        SaleId = saleId;
        Product = product;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = 0;
        CalculateTotal();
    }

    public void ApplyDiscount(decimal discountRate)
    {
        if (discountRate < 0 || discountRate > 1)
            throw new ArgumentException("Invalid discount rate.");

        Discount = UnitPrice * discountRate;
        CalculateTotal();
    }

    private void CalculateTotal()
    {
        Total = (UnitPrice - Discount) * Quantity;
    }
}
