using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DavidProduct.Models
{
  public class Product
  {
    public int ProductID { get; set; }

    [Required(ErrorMessage ="Please enter product name")]
    public string Name { get; set; }

    [Required(ErrorMessage ="Please enter a price")]
    [Column(TypeName = "decimal(18)" )]
    public decimal Price { get; set; }

    [Required(ErrorMessage ="please select a category")]
    public int CategoryID { get; set; }

    public Category Category { get; set; }

    public decimal DiscountPercent => .20M;
    public decimal DiscountAmount => Price * DiscountPercent;
    public decimal DiscountPrice => Price - DiscountAmount;


    public string Code { get; set; }

    public string Slug => Name==null ? "" : Name.Replace(' ', '-');
  }
}
