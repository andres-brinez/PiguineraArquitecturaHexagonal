using PandemyLagacyDDD.Domain.Generic;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Commands
{
    internal class CreateSupplierCommnad : InitialCommand
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
