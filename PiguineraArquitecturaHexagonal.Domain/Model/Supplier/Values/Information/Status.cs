using PiguineraArquitecturaHexagonal.Domain.Generic;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Information
{
    public class Status : IValueObject<bool>
    {
        private readonly bool IsActive;

        public Status(bool isActive)
        {
            if (isActive == null)
            {
                throw new ArgumentNullException(nameof(isActive), "El estado no puede ser nulo.");
            }

            IsActive = isActive;
        }

        

        public static Status Of(bool isActive)
        {
            return new Status(isActive);
        }

        public bool Value()
        {
            return IsActive;
        }

    }
}