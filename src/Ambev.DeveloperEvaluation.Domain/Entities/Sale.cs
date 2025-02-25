namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Customer { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string Branch { get; private set; }
        public bool IsCancelled { get; private set; }
        private readonly List<SaleItem> _items = [];

        public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();

        private Sale() { } // Required for EF Core

        public Sale(string customer, string branch, IEnumerable<SaleItem> items)
        {
            Id = Guid.NewGuid();
            Date = DateTime.UtcNow;
            Customer = customer ?? throw new ArgumentException("Customer is required");
            Branch = branch ?? throw new ArgumentException("Branch is required");
            AddItems(items);
            CalculateTotal();
        }

        private void AddItems(IEnumerable<SaleItem> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public void AddItem(SaleItem item)
        {
            if (item.Quantity > 20)
                throw new InvalidOperationException("Cannot sell more than 20 units of the same item.");

            if (item.Quantity >= 10)
                item.ApplyDiscount(0.20m);
            else if (item.Quantity >= 4)
                item.ApplyDiscount(0.10m);

            _items.Add(item);
            CalculateTotal();
        }

        public void Cancel()
        {
            if (IsCancelled)
                throw new InvalidOperationException("Sale is already cancelled.");

            IsCancelled = true;
        }

        private void CalculateTotal()
        {
            TotalAmount = _items.Sum(i => i.Total);
        }

        public void Update(string? customer, string? branch, List<SaleItem> updatedItems)
        {
            throw new NotImplementedException();
        }
    }

}
