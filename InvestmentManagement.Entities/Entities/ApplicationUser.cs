using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string CPF { get; set; }
    }
}
