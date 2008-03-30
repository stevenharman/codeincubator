using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MvcDemoApp.Models
{
    public partial class AdventureWorksDataContext
    {
        public List<ProductModel> GetProductModels()
        {
            return ProductModels.ToList<ProductModel>();
        }

        public List<Product> GetProductsByModel(string model)
        {
            return Products.Where(m => m.ProductModel.Name == model).ToList<Product>();
        }

        public List<Product> GetTenProductsByModel(string model)
        {
            return Products.Where(m => m.ProductModel.Name == model).Take(10).ToList<Product>();
        }

        public List<Product> GetTenProducts()
        {
            return Products.Where(p => p.ListPrice > 0.0M).Take(10).ToList<Product>();
        }

        public Product GetProductById(int id)
        {
            return Products.Single<Product>(p => p.ProductID == id);
        }
    }
}
