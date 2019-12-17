using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectrum.Model.Model;
using Spectrum.Repository.Repository;

namespace Spectrum.Bll.Bll
{
    public class SalesManager
    {
        SalesRepository _salesRepository = new SalesRepository();
        public bool AddSales(Sales sales)
        {
            return _salesRepository.AddSales(sales);
        }
        public List<SalesDetails> GetAllSalesDetails()
        {
            return _salesRepository.GetAllSalesDetails();
        }
    }
}
