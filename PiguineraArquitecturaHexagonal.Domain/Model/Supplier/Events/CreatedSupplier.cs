using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Events
{
    public class CreatedSupplier: DomainEvent
    {
        public string Email;
        public string Password;
        public DateTime RegisterDate;
        public int Seniority;

        public CreatedSupplier(string email,string password, DateTime registerDate,int seniority) : base(EventsEnumSupplier.SUPPLIER_CREATED.ToString(), $"{{\"email\":\"{email}\",\"password\":\"{password}\",\"registerDate\":\"{registerDate}\",\"seniority\":{seniority}}}")
        {
            Email = email;
            Password = password;
            RegisterDate = registerDate;

        }
    }
}
