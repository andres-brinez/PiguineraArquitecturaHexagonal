
using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Purchese
{
    public class QuantityBooks : IValueObject<int>
    {
        private readonly int quantity;

        public QuantityBooks(List<Entities.Book> books)
        {
            if (books == null)
            {
                throw new ArgumentOutOfRangeException(nameof(books), "La lista de libros no puede ser null");
            }

            quantity = books.Sum(book=>book.GetQuantity());

        }

        public static QuantityBooks Of(List<Entities.Book> books)
        {
            return new QuantityBooks(books);
        }

        public int Value()
        {
            return quantity;
        }

    }

}
