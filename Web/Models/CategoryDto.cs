using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "category name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}