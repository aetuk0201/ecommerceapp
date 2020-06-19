namespace Web.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Department { get; set; }
        public string Category { get; set; }
        public string ProductType { get; set; }
        public int Quantity { get; set; }
        public int QtyInStock { get; set; }
        public string Code { get; set; }
        public int Rating { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string ImageUrl { get; set; }
    }
}