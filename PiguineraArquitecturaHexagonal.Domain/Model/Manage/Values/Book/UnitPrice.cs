

using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book
{
    public class UnitPrice : IValueObject<double>
    {
        private readonly double _price; 

        public UnitPrice(double price)
        {
            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "El precio unitario debe ser mayor que 0.");
            }

            _price = price;
        }

        public static UnitPrice Of(double price)
        {
            return new UnitPrice(price);
        }

        public double Value() 
        {
            return _price;
        }

    }

}
