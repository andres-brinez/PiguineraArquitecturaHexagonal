using PandemyLagacyDDD.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Entities;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Events;


namespace PandemyLagacyDDD.Domain.Model.City.Events.Configuration
{
    public class SupplierEventChange : EventChange
    {
        public SupplierEventChange(SupplierAgregateRoot supplier)
        {

            AddSub((DomainEvent @event) =>
            {
                if (@event is not CreatedSupplier) return;
                if (@event is not ) return;
                var domainEvent = (CreatedSupplier)@event;

                supplier.UserCredential = new UserCredential(domainEvent.Email, domainEvent.Password);
                supplier.Information = new Information("Andres", "", "2323");
                supplier.Information.CalculateSeniority(supplier.UserCredential.GetRegistrationDate());


            });

            AddSub((DomainEvent @event) =>
            {
                if (@event is not CalculatedSeniority) return;
                var domainEvent = (CalculatedSeniority)@event;

                supplier.Information.CalculateSeniority(supplier.UserCredential.GetRegistrationDate());
            });
          
        }
    }
}