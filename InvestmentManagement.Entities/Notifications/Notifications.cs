using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Entities.Notifications
{
    public class Notifica
    {
        public Notifica()
        {
            Notification = new List<Notifica>();
        }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notifica> Notification { get; set; }

        public bool PropertyValidString(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
            {
                Notification.Add(new Notifica()
                {
                    Message = "Campo Obrigatório",    
                    PropertyName = propertyName
                });

                return false;
            }
            return true;
        }

        public bool PropertyValidInt(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notification.Add(new Notifica()
                {
                    Message = "Campo Obrigatório",
                    PropertyName = "Nome Propriedade"
                });

                return false;
            }
            return true;
        }
    }
}
