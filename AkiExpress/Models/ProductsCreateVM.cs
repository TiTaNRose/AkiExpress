using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkiExpress.Models
{
    public class ProductsCreateVM
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Select Category")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public string Quantity { get; set; }
        [Required]
        [Display(Name = "Price in $")]
        public string Price { get; set; }

        // Images
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Thumbnail")]
        public string Thumbnail { get; set; }
        public string Image01 { get; set; }
        public string Image02 { get; set; }
        public string Image03 { get; set; }
        public string Image04 { get; set; }
        public string Image05 { get; set; }

    }
}
