using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spectrum.Model.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Spectrum.Models
{
    public class SalesViewModel
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

        public List<SalesDetails> SalesDetails { set; get; }
        //

        public int Code { set; get; }
        public int CustomerId { set; get; }
        public string CustomerName { set; get; }
        public Customer Customer { set; get; }
        public DateTime Date { set; get; }
        public int LoyaltyPoint { set; get; }

        public List<SelectListItem> CustomerSelectListItems { set; get; }




        public int CategoryId { set; get; }
        public Category Category { set; get; }
        public List<SelectListItem> CategorySelectListItems { set; get; }

    }
}