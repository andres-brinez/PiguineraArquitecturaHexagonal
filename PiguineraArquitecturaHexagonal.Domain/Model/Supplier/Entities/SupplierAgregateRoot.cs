using PandemyLagacyDDD.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Supplier;
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

        public SupplierAgregateRoot(String email, string password) : base(new SupplierId())
        {
            UserCredential= new UserCredential(email, password);
            Information = new Information("", "", "");
            Information.CalculateSeniority(UserCredential.GetRegistrationDate());

        }
    }
}
