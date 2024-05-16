using PiguineraArquitecturaHexagonal.Domain.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.UserCredential
{
    public class Password : IValueObject<string>
    {
        private string PasswordHash { get; set; }

 

        public Password (string plainTextPassword)
        {
            if (string.IsNullOrEmpty(plainTextPassword))
            {
                throw new ArgumentException("La contraseña no puede estar vacía.", nameof(plainTextPassword));
            }

            using (var sha256 = SHA256.Create())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(plainTextPassword);
                var hashBytes = sha256.ComputeHash(passwordBytes);
                this.PasswordHash = passwordBytes.ToString();
            }
        }

        public static Password Of(string passwordHash)
        {
            if (passwordHash == null || passwordHash.Length == 0)
            {
                throw new ArgumentException("El hash de la contraseña no puede estar vacío.", nameof(passwordHash));
            }


            return new Password(passwordHash);
        }

        public string Value()
        {
            return PasswordHash;
        }

    }
}
