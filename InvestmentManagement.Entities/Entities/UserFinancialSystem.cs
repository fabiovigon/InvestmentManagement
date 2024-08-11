using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Entities.Entities
{
    public class UserFinancialSystem
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool Administrator { get; set; }
        public bool CurrentSystem { get; set; }

        [ForeignKey("FinancialSystem")]
        [Column(Order = 1 )]
        public int IdSystem { get; set; }
        public virtual FinancialSystem FinancialSystem { get; set; }
    }
}
