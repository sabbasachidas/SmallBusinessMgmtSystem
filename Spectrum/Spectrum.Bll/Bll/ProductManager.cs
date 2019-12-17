using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectrum.Model.Model;
using Spectrum.Repository.Repository;

namespace Spectrum.Bll.Bll
{
    public class ProductManager
    {
        ProductRepository _productRepository= new ProductRepository();
        public bool Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product getById(int id)
        {
            return _productRepository.getById(id);
        }

        public bool Update(Product product)
        {
            return _productRepository.Update(product);
        }

        public bool Delete(int id)
        {
            return _productRepository.Delete(id);
        }
    }
}
