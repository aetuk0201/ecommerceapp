using System.Collections.Generic;

namespace Web.Models
{
    public class CustomerCartDto
    {
        public string Id { get; set; }
        public List<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();

    }
}