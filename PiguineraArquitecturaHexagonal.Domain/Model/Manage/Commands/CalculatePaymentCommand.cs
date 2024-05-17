

using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands
{
    public class CalculatePaymentCommand : InitialCommand
    
    {
        public string IdSupplier;
        public List<string> BooksId;
        public List<Entities.Book> Books;
        public float TotalPrice;
        public string TypePurchase;
        public int QuantityBooks;

        public CalculatePaymentCommand( string idSupplier,
                                        List<string> booksId,
                                        List<Book> books,
                                        float totalPrice,
                                        string typePurchase,
                                        int quantityBooks)
        {
            IdSupplier = idSupplier;
            BooksId = booksId;
            Books = books;
            TotalPrice = totalPrice;
            TypePurchase = typePurchase;
            QuantityBooks = quantityBooks;
        }
    }
}
