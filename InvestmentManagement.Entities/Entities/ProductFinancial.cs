using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Entities.Entities
{
    [Table("ProductFinancial")]
    public class ProductFinancial : Base
    {
        public decimal Value { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Dt_Inclusion  { get; set; }
        public DateTime Dt_Change { get; set; }
        public DateTime Dt_ExpiredProduct { get; set; }
        public bool ProductExpired { get; set; }

        [ForeignKey("UserFinancialSystem")]
        public int IdUserFinancialSystem { get; set; }

        [ForeignKey("Categories")]
        [Column(Order = 1)]
        public int IdCategory { get; set; }
        public virtual Categories Category { get; set; }
    }
}
