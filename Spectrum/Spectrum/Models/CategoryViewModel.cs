using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spectrum.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace Spectrum.Models
{
    public class CategoryViewModel
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "Can not be empty!")]
        [MinLength(4, ErrorMessage = "Must be 4 digit")]
        [MaxLength(4, ErrorMessage = "Must be 4 digit")]
        public string Code { set; get; }
        [Required(ErrorMessage = "Can not be empty!")]
        public string Name { set; get; }

        public List<Category> Categories { set; get; }
        

    }
}