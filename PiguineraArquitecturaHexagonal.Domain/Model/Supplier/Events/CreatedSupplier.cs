using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Events
{
    public class CreatedSupplier: DomainEvent
    {
        public string Name;
        public string Email;
        public string Password;
        public DateTime RegisterDate;
        public int Seniority;

        public CreatedSupplier(string name, string email,string password, DateTime registerDate,int seniority) : base(EventsEnumSupplier.SUPPLIER_CREATED.ToString(), $"{{\"name\":\"{name}\",\"email\":\"{email}\",\"password\":\"{password}\",\"registerDate\":\"{registerDate}\",\"seniority\":{seniority}}}")
        {
            Name = name;
            Email = email;
            Password = password;
            RegisterDate = registerDate;

        }
    }
}
