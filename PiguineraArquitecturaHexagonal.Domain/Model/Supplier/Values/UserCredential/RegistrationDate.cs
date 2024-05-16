using PandemyLagacyDDD.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.UserCredential
{
    public class RegistrationDate : IValueObject<DateTime>
    {
        private readonly DateTime RegistrationDateValue;

        public RegistrationDate()
        {
            RegistrationDateValue = DateTime.UtcNow; 


            if (RegistrationDateValue > DateTime.UtcNow)
            {
                throw new ArgumentException("La fecha de registro no puede ser posterior a la fecha actual.", nameof(registrationDate));
            }

        }

        
        public DateTime Value()
        {
            return RegistrationDateValue;
        }

    }
}