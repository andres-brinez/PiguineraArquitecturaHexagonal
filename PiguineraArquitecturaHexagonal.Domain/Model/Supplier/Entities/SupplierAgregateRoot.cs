using PandemyLagacyDDD.Domain.Generic;
using PandemyLagacyDDD.Domain.Model.City.Events.Configuration;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Events;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Information;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Supplier;
using System.Drawing;
using System.Linq.Expressions;

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
            AppendEvent(new CreatedSupplier(email,password));


        }
    }
}
