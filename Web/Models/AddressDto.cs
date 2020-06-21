namespace Web.Models
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string AddressType { get; set; }
        public string AppUserId { get; set; }
    }
}