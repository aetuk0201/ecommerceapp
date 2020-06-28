using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "department name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}