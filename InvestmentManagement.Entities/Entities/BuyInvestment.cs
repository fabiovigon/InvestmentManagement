using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Entities.Entities
{
    [Table("InvestmentOperation")]
    public class BuyInvestment : Base
    {
        [ForeignKey("ProductFinancial")]
        [Column(Order = 1)]
        public int IdProductFinancial { get; set; }
        public DateTime Dt_BuyInvestment { get; set; }
        public DateTime Dt_SellInvestment { get; set; }
    }
}
