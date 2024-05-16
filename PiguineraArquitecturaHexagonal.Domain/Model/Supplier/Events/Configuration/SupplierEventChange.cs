using PandemyLagacyDDD.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Entities;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Events;


namespace PandemyLagacyDDD.Domain.Model.City.Events.Configuration
{
    public class SupplierEventChange : EventChange
    {
        public SupplierEventChange(SupplierAgregateRoot supplier)
        {

            //AddSub((DomainEvent @event) =>
            //{
            //    if (@event is not ResearchCenterBuilt) return;
            //    var domainEvent = (ResearchCenterBuilt)@event;

            //    city.researchCenter.AddCenter(domainEvent.CapacityValue);
            //});

    

            AddSub((DomainEvent @event) =>
            {
                if (@event is not ) return;
                var domainEvent = (CreatedSupplier)@event;

                supplier.UserCredential = new UserCredential(domainEvent.Email, domainEvent.Password);
                supplier.Information = new Information("Andres", "Colombia", "2323");
                supplier.Information.CalculateSeniority(supplier.UserCredential.GetRegistrationDate());
                

            });
        }
    }
}