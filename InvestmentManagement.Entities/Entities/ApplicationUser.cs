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
        [Column("CPF")]
        public string CPF { get; set; }

        [Column("Balance")]
        public string  Balance { get; set; }
    }
}
