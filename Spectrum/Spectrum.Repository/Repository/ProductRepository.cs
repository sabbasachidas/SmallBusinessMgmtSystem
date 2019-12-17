using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectrum.Model.Model;
using Spectrum.DatabaseContext.DatabaseContext;

namespace Spectrum.Repository.Repository
{
   public class ProductRepository
    {

        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Product product)
        {
            _dbContext.Product.Add(product);
            return _dbContext.SaveChanges() > 0;
        }

        public List<Product> GetAll()
        {
            return _dbContext.Product.ToList();
        }

        public Product getById(int id)
        {
            return _dbContext.Product.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(Product product)

        {
            Product aProduct = _dbContext.Product.FirstOrDefault(c => c.Id == product.Id);
            if (aProduct != null)
            {

                aProduct.Code = product.Code;
                aProduct.Name = product.Name;
                aProduct.Reorderlevel = product.Reorderlevel;
                aProduct.Description = product.Description;
            }
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Product aProduct = _dbContext.Product.FirstOrDefault(c => c.Id == id);
            _dbContext.Product.Remove(aProduct);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
