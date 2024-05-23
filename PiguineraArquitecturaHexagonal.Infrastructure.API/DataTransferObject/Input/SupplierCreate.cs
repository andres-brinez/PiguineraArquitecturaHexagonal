﻿namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Input
{
    public class SupplierCreate
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public SupplierCreate(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
