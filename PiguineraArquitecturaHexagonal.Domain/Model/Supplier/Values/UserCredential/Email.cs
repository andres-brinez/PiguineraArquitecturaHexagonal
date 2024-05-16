
using PiguineraArquitecturaHexagonal.Domain.Generic;
using System.Text.RegularExpressions;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.UserCredential
{
    public class Email : IValueObject<string>
    {
        private string EmailAddressValue;

        public Email(string emailAddress)
        {
            if (!IsValidEmailAddress(emailAddress))
            {
                throw new ArgumentException("La dirección de correo electrónico no es válida.", nameof(emailAddress));
            }

            EmailAddressValue = emailAddress;
        }

        public static Email Of(string emailAddress)
        {
            return new Email(emailAddress);
        }



        public string Value()
        {
            return EmailAddressValue;
        }

        private bool IsValidEmailAddress(string emailAddress)
        {
            const string emailRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4})$";
            return Regex.IsMatch(emailAddress, emailRegex);
        }
    }
}