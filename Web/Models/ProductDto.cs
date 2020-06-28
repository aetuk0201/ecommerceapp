using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "product name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "price is required")]
        [Range(0.1, double.MaxValue, ErrorMessage = "price must be greater than 0")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "department is required")]
        public string Department { get; set; }
        [Required(ErrorMessage = "category is required")]
        public string Category { get; set; }
        [Required(ErrorMessage = "product type is required")]
        public string ProductType { get; set; }
        [Required(ErrorMessage = "quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "quantity must be greater than 0")]
        public int Quantity { get; set; }
        public int QtyInStock { get; set; }
        public string Code { get; set; }
        public int Rating { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string ImageUrl { get; set; }
    }
}