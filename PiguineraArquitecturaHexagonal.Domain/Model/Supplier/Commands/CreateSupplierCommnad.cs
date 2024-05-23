using PiguineraArquitecturaHexagonal.Domain.Generic;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Commands
{
    public class CreateSupplierCommnad : InitialCommand
    {
        public string UserName;
        public string Email;
        public string Password;

        public CreateSupplierCommnad(string name, string email, string password)
        {
            UserName = name;
            Email = email;
            Password = password;
        }
    }
}
