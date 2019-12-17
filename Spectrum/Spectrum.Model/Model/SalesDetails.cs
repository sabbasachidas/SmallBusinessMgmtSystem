using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum.Model.Model
{
    public class SalesDetails
    {

        public int Id { set; get; }
        public int ProductId { set; get; }
        public string ProductName { set; get; }
        public Product Product { set; get; }
        public int Quantity { set; get; }
        public int MRP { set; get; }
        public int TotalMrp { set; get; }
        public int SalesId { set; get; }
        public Sales Sales { set; get; }
    }
}
