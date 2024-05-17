using PiguineraArquitecturaHexagonal.Domain.Generic;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book
{
    public class OriginalPrice : IValueObject<int>
    {
        private readonly int price;

        public OriginalPrice(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "El precio original debe ser mayor que 0.");
            }

            price = value;
        }

        public static OriginalPrice Of(int value)
        {
            return new OriginalPrice(value);
        }

        public int Value()
        {
            return price;
        }

    }
}