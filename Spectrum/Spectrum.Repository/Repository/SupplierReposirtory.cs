using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectrum.Model.Model;
using Spectrum.DatabaseContext.DatabaseContext;


namespace Spectrum.Repository.Repository
{
   public class SupplierReposirtory
    {
        ProjectDbContext _dbContext = new ProjectDbContext();

        public bool Add(Supplier supplier)
        {
            _dbContext.Supplier.Add(supplier);
            return _dbContext.SaveChanges() > 0;
        }

        public List<Supplier> GetAll()
        {
            return _dbContext.Supplier.ToList();
        }

        public Supplier getById(int id)
        {
            return _dbContext.Supplier.FirstOrDefault(c => c.Id == id);
        }
        public bool Update(Supplier supplier)
        {
            Supplier aSupplier = _dbContext.Supplier.FirstOrDefault(c => c.Id == supplier.Id);
            if (aSupplier != null)
            {
                aSupplier.Code = supplier.Code;
                aSupplier.Name = supplier.Name;
                aSupplier.Address = supplier.Address;
                aSupplier.Email = supplier.Email;
                aSupplier.Contact = supplier.Contact;
                aSupplier.ContactPerson = supplier.ContactPerson;
            }
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Supplier aSupplier = _dbContext.Supplier.FirstOrDefault(c => c.Id == id);
            _dbContext.Supplier.Remove(aSupplier);
            return _dbContext.SaveChanges() > 0;
        }

    }
}
