using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string AddressType { get; set; }
        [Required]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}