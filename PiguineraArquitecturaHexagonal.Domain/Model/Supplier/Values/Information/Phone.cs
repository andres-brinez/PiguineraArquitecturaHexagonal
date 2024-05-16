using PandemyLagacyDDD.Domain.Generic;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Information
{
    public class Phone : IValueObject<string>
    {
        private readonly string PhoneNumberValue;

        public Phone(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentException("El número de teléfono no puede estar vacío.", nameof(phoneNumber));
            }

            PhoneNumberValue = phoneNumber;
        }

        public static Phone Of(string phoneNumber)
        {
            return new Phone(phoneNumber);
        }

        public string Value()
        {
            return PhoneNumberValue;
        }

    }
}