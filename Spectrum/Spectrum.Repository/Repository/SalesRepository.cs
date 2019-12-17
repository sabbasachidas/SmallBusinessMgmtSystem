using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectrum.Model.Model;
using Spectrum.DatabaseContext.DatabaseContext;
namespace Spectrum.Repository.Repository
{
    public class SalesRepository
    {

        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool AddSales(Sales sales)
        {
            _dbContext.Sales.Add(sales);
            return _dbContext.SaveChanges() > 0;
        }
        public List<SalesDetails> GetAllSalesDetails()
        {
            return _dbContext.SalesDetails.ToList();
        }
    }
}
