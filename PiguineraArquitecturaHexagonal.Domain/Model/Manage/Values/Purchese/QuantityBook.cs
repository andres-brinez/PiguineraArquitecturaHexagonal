
using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Purchese
{
    public class QuantityBook : IValueObject<int>
    {
        private readonly int quantity;

        public QuantityBook(List<Entities.Book> books)
        {
            if (books == null)
            {
                throw new ArgumentOutOfRangeException(nameof(books), "La lista de libros no puede ser null");
            }

            quantity = books.Sum(book=>book.GetQuantity());

        }

        public static QuantityBook Of(List<Entities.Book> books)
        {
            return new QuantityBook(books);
        }

        public int Value()
        {
            return quantity;
        }

    }

}
