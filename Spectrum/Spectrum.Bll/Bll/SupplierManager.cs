using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Spectrum.Model.Model;
using Spectrum.Repository.Repository;

namespace Spectrum.Bll.Bll
{
   public class SupplierManager
    {
        SupplierReposirtory _supplierReposirtory = new SupplierReposirtory();

        public bool Add(Supplier supplier)
        {
            return _supplierReposirtory.Add(supplier);
        }

        public List<Supplier> GetAll()
        {
            return _supplierReposirtory.GetAll();
        }

        public Supplier getById(int id)
        {
            return _supplierReposirtory.getById(id);
        }

        public bool Update(Supplier supplier)
        {
            return _supplierReposirtory.Update(supplier);
        }

        public bool Delete(int id)
        {
            return _supplierReposirtory.Delete(id);
        }


    }
}
