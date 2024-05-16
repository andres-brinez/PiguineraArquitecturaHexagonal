using PandemyLagacyDDD.Domain.Generic;
using PandemyLagacyDDD.Domain.Model.City.Events.Configuration;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Events
{
    public class CreatedSupplier: DomainEvent
    {
        public string Email;
        public string Password;

        public CreatedSupplier(string email,string password) : base(EventsEnumSupplier.SUPPLIER_CREATED.ToString())
        {
            Email = email;
            Password = password;
        }
    }
}
