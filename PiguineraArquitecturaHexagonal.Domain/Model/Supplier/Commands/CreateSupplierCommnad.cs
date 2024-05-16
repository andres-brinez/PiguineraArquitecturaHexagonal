using PiguineraArquitecturaHexagonal.Domain.Generic;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Commands
{
    public class CreateSupplierCommnad : InitialCommand
    {
        public string Email;
        public string Password;

        public CreateSupplierCommnad(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
