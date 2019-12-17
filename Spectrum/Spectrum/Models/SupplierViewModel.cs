using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spectrum.Model.Model;
using System.ComponentModel.DataAnnotations;


namespace Spectrum.Models
{
    public class SupplierViewModel
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Can not be empty!")]
        [MinLength(4, ErrorMessage = "Must be 4 digit")]
        [MaxLength(4, ErrorMessage = "Must be 4 digit")]
        public string Code { set; get; }
        [Required(ErrorMessage = "Can not be empty!")]
        public string Name { set; get; }
        public string Address { set; get; }
        [Required(ErrorMessage = "Can not be empty!")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Can not be empty!")]
        public string Contact { set; get; }
        public string ContactPerson { set; get; }

        public List<Supplier> Suppliers { set; get; }

    }
}