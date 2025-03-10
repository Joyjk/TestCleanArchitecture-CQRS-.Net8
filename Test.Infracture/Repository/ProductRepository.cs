using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.IRepository;
using Test.Domain.Model;
using Test.Infracture.DBContext;

namespace Test.Infracture.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly DatabaseDbContext _dBContext;
        public ProductRepository(DatabaseDbContext databaseDb)
        {
            _dBContext = databaseDb;
        }

       

        public Product GetProductbyName(string Name)
        {
            var data = _dBContext.Products.FirstOrDefault(d => d.ProductName == Name);
            return data ?? new Product();
        }
        public List<Product> GetProductSearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new List<Product>();

            return _dBContext.Products
                .Where(d => d.ProductName.ToLower().Contains(name.ToLower()))
                .ToList();
        }

        public bool SaveProduct(Product product, string createby)
        {
            product.CreateBy = createby;
            _dBContext.Products.Add(product);
            return _dBContext.SaveChanges() > 0;
        }

        public bool UpdateProduct(Product product, string updateby)
        {
            var data = _dBContext.Products.Where(d => d.ProductId == product.ProductId).FirstOrDefault();
            if (data == null)
                return false;

            data.ProductName = product.ProductName;
            data.CreateBy = updateby;
            return _dBContext.SaveChanges() > 0;
        }
        public bool DeleteProduct(Product product)
        {
            _dBContext.Products.Remove(product);
            return _dBContext.SaveChanges() > 0;
        }
    }
}
