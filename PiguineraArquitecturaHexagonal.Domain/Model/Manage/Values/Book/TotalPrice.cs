

using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book
{
    public class TotalPrice : IValueObject<double>
    {
        private readonly double _price;

        public TotalPrice(double price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "El precio  no debe ser menor a 0.");
            }

            _price = price;
        }

        public static TotalPrice Of(double price)
        {
            return new TotalPrice(price);
        }

        public double Value()
        {
            return _price;
        }

    }

}