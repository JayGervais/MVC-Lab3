using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JayGervais_CPRG215_MVC_Lab3.Models
{
    public class Product
    {
        public Product() { }

        [Required]
        [StringLength(10)]
        public string ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string ShortDescription { get; set; }

        [Required]
        [StringLength(2000)]
        public string LongDescription { get; set; }

        [Required]
        [StringLength(10)]
        public string CategoryID { get; set; }

        [StringLength(10)]
        public string ImageFile { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0, 1000)]
        public double UnitPrice { get; set; }

        [Required]
        [Range(0, 1000)]
        public int OnHand { get; set; }
    }
}