
using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book
{
    public class Quantity : IValueObject<int>
    {
        private readonly int _quantity;

        public Quantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "La cantidad  no debe ser menor que 0.");
            }

            _quantity = quantity;
        }

        public static Quantity Of(int quantity)
        {
            return new Quantity(quantity);
        }

        public int Value() 
        {
            return _quantity;
        }

    }
}
