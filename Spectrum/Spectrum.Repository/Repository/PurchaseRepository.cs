using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectrum.DatabaseContext.DatabaseContext;
using Spectrum.Model.Model;

namespace Spectrum.Repository.Repository
{
public class PurchaseRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Purchase purchase)
        {
            _dbContext.Purchases.Add(purchase);
            return _dbContext.SaveChanges() > 0;
        }
        public List<PurchaseDetails> GetAll()
        {
            return _dbContext.PurchaseDetailses.ToList();
        }
        public List<Purchase> GetPurchaseReportAll()
        {
            return _dbContext.Purchases.ToList();
        }

    }
}
