using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Orders
{
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

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductOrderedId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
    }
}