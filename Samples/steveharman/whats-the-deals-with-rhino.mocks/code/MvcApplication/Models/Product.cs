using System;

namespace MvcApplication.Models
{
    public class Product : IProduct
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}