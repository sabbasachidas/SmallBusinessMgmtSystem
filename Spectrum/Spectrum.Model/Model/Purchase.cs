using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum.Model.Model
{
    public class Purchase
    {
        public Purchase()
        {
            PurchaseDetailses = new List<PurchaseDetails>();

        }

        public int Id { set; get; }

        //public int purchaseCode;
        //public int GeneratCode(int purchaseCode=2019)
        //{
        //    this.purchaseCode = purchaseCode;
        //    return this.purchaseCode--;
        //}

        public int Code { set; get; }

        //public int Code {
        //    set { this.purchaseCode = value; }
        //    get { return this.purchaseCode; }
        //}
        public DateTime Date { set; get; }
        public string InvoiceNo { set; get; }

        public string SupplierName { set; get; }
        public int SupplierId { set; get; }
        public Supplier Supplier { set; get; }

        public List<PurchaseDetails> PurchaseDetailses { set; get; }
    }
}