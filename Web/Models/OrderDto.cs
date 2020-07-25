namespace Web.Models
{
    public class OrderDto
    {
        public string CartId { get; set; }
        public int DeliveryMethodId { get; set; }
        public AddressDto AddressToShip { get; set; }
    }
}