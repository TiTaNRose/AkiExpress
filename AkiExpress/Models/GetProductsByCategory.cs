using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkiExpress.Models
{
    public class GetProductsByCategory
    {

        public GetProductsByCategory()
        {
            Products = new List<Products>();
        }

        public List<Products> Products { get; set; }
    }
}

