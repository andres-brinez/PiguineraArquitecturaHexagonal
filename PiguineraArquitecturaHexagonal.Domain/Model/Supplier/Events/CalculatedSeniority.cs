using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Events.Configuration;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Events
{
    public class CalculatedSeniority : DomainEvent
    {
        public DateTime registerDate;

        public CalculatedSeniority(DateTime registerDate):base(EventsEnumSupplier.SENIORITY_CALCULTED.ToString(), registerDate.ToString())
        {
            this.registerDate = registerDate;
        }
    }
}
