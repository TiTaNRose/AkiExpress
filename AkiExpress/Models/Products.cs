using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AkiExpress.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public string Price { get; set; }

        public string CategoryName { get; set; }

        //Relationship wih categories
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public List<Categories> Categories { get; set; }

        // Images
        public string Thumbnail { get; set; }
        public string Image01 { get; set; }
        public string Image02 { get; set; }
        public string Image03 { get; set; }
        public string Image04 { get; set; }
        public string Image05 { get; set; }
    }
}
