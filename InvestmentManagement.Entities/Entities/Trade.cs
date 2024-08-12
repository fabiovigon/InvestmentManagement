using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Entities.Entities
{
    [Table("InvestmentOperation")]
    public class Trade : Base
    {
        [ForeignKey("ProductFinancial")]
        public int ProductId { get; set; }
        public string UserEmail { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime TradeDate { get; set; }
        public string TradeType { get; set; } // "Buy" ou "Sell"
    }
}
