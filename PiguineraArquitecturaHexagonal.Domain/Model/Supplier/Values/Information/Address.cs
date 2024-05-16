using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Information
{
    public class Address : IValueObject<string>
    {
        private readonly string AddressValue;

        public Address(string addressString)
        {
            if (string.IsNullOrEmpty(addressString))
            {
                throw new ArgumentException("La dirección no puede estar vacía.", nameof(addressString));
            }

            AddressValue = addressString;
        }

        public static Address Of(string addressString)
        {
            return new Address(addressString);
        }

        public string Value()
        {
            return AddressValue;
        }

    }
}