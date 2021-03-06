using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities.Orders
{
    [Owned]
    public class ProductOrdered
    {
        public ProductOrdered()
        {

        }
        public ProductOrdered(int productOrderedId, string productName, string imageUrl)
        {
            ProductOrderedId = productOrderedId;
            ProductName = productName;
            ImageUrl = imageUrl;
        }

        public int ProductOrderedId { get; set; }
        public string ProductName { get; set; }


        public string ImageUrl { get; set; }
    }
}