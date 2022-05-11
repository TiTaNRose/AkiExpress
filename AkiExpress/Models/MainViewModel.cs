using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkiExpress.Models
{
    public class MainViewModel
    {
        public IEnumerable<Products> Products { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
    }
}
