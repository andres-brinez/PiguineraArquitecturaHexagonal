using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.City.Events.Configuration;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Events;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Information;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Supplier;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Entities
{
    public class SupplierAgregateRoot : AggregateRoot<SupplierId>
    {
        public Information Information;
        public UserCredential UserCredential;

        public SupplierAgregateRoot(SupplierId identity) : base(identity)
        {

        }

        public SupplierAgregateRoot(string email, string password) : base(new SupplierId())
        {

            Subscribe(new SupplierEventChange(this));

            DateTime registerDate = new DateTime(2012, 7, 15, 8, 30, 0);

            TimeSpan tiempoTranscurrido = DateTime.UtcNow - registerDate;
            int añosTranscurridos = (int)(tiempoTranscurrido.Days / 365.25); 

            int seniority = añosTranscurridos;

            AppendEvent(new CreatedSupplier(email,password,DateTime.Now, seniority));

        }

    }
}
