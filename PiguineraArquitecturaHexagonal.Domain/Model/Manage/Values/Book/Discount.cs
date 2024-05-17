
using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book
{
    public class Discount : IValueObject<decimal>
    {
        private readonly decimal Percentage;

        public Discount(decimal percentage)
        {
            if (percentage < 0 || percentage > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percentage), "El descuento debe estar entre 0 y 100%.");
            }

            Percentage = percentage;
        }

        public static Discount Of(decimal percentage)
        {
            return new Discount(percentage);
        }

        public decimal Value()
        {
            return Percentage;
        }

    }
}