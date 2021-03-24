using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DavidProduct.Models
{
    public class Category
    {
        public int CategoryID { get; set; }


        [Required(ErrorMessage ="Please enter category name")]
        public string Name { get; set; }
    }
}
