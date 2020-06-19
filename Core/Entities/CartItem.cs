namespace Core.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Department { get; set; }
        public string Category { get; set; }
        public string ProductType { get; set; }
    }
}