namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public int Quantity { get; set; }
        public int QtyInStock { get; set; }
        public string Code { get; set; }
        public int Rating { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string ImageUrl { get; set; }
        public string ImageMimeType { get; set; }
    }
}