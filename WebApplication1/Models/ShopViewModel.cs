using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class ShopViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> DiscountedProducts { get; set; }
        public List<Product> LatestProducts { get; set; }
    }
}