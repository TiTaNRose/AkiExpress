using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkiExpress.Models
{
    public class AkiUsers : IdentityUser
    {
        [Required]
        public string Name { get; set; }
    }
}
