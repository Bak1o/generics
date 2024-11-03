using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class ProductService
    {
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>
        {
            new Product
        {
            Id = 1,
            Name = "Ipad",
            Price = 1999m
        },
            new Product
        {
            Id = 2,
            Name = "Airpod",
            Price = 1699m
        },
            new Product
        {
            Id = 3,
            Name = "Airpod",
             Price = 1699m
        },
            new Product
        {
            Id = 4,
            Name = "Xbox",
            Price = 1899
        },
           };
            return products;
        }
    }
}
