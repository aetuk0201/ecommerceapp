using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class AddressDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "address is required")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage = "city is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "state is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "zip code is required")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "address type is required")]
        public string AddressType { get; set; }
        public string AppUserId { get; set; }
    }
}