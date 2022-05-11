using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkiExpress.Models
{
    public class CategoriesDropDownList
    {
        public CategoriesDropDownList()
        {
            Categories = new List<Categories>();
        }

        public List<Categories> Categories { get; set; }
    }
}
