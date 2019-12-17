using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum.Model.Model
{
    public class PurchaseDetails
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public DateTime ManuFractureDateTime { set; get; }
        public DateTime ExpireDateTime { set; get; }
        public string Remarks { set; get; }
        public int Quantity { set; get; }
        public int UnitPrice { set; get; }
        public int TotalPrice { set; get; }
        public int MRP { set; get; }

        public int ProductId { set; get; }
        public Product Product { set; get; }
        public int PurchaseId { set; get; }
        public Purchase Purchase { set; get; }
    }
}
