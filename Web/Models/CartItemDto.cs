using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CartItemDto
    {
        [Required(ErrorMessage = "cart Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "product name is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "price is required")]
        [Range(0.1, double.MaxValue, ErrorMessage = "price must be greater than zero")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "quantity must be greater than zero")]
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "department is required")]
        public string Department { get; set; }
        [Required(ErrorMessage = "category is required")]
        public string Category { get; set; }
        [Required(ErrorMessage = "product type is required")]
        public string ProductType { get; set; }
    }
}