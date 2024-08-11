using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Entities.Entities
{
    [Table("FinancialSystem")]
    public class FinancialSystem : Base
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int Day { get; set; }
        public DateTime ClosingDay { get; set; }
        public bool SendEmailProductExpiration { get; set; }
    }
}
