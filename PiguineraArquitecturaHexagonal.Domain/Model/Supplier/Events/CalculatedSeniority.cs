using PandemyLagacyDDD.Domain.Generic;
using PandemyLagacyDDD.Domain.Model.City.Events.Configuration;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Events
{
    public class CalculatedSeniority : DomainEvent
    {

        public CalculatedSeniority() : base(EventsEnumSupplier.SUPPLIER_CREATED.ToString())
        {
        }
    }
}