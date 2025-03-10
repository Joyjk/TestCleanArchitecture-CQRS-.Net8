using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Model;

namespace Test.Domain.IRepository
{
    public interface IProductRepository
    {
        Product GetProductbyName(string Name);
        List<Product> GetProductSearchByName(string name);
        bool SaveProduct(Product product, string createby);
        bool DeleteProduct(Product product);
        bool UpdateProduct(Product product, string updateby);
    }
}
