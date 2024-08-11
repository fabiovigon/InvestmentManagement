using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentManagement.Entities.Notifications;

namespace InvestmentManagement.Entities.Entities
{
    public class Base : Notifica
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
