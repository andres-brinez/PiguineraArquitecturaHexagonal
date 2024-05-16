﻿namespace PiguineraArquitecturaHexagonal.Api.DataTransferObject
{
    public class SupplierCreate
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public SupplierCreate(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
