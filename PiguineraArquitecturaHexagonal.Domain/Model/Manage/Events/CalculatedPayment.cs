
using Newtonsoft.Json;

using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Events.Configuration;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Events
{
    public class CalculatedPayment : DomainEvent
    {
        public string IdSupplier;
        public List<string> BooksId;

        public List<Entities.Book> Books;

        public float TotalPrice;
        public string TypePurchase;
        public int QuantityBooks;

        public CalculatedPayment(   string idSupplier,
                                    List<string> booksId,
                                    List<Book> books,
                                    float totalPrice,
                                    string typePurchase,
                                    int quantityBooks
                                ) :
                                    base(EventsEnumManage.CALCULATEDPAYMENT.ToString(),
                                         $"{{\"IdSupplier\":\"{idSupplier}\"," +
                                           //$"\"Books\":\"{JsonConvert.SerializeObject(books)}\"," +
                                           $"\"Books\":[{string.Join(",", books.Select(book => book.ToString()))}]," +

                                         $"\"totalPrice\":\"{totalPrice}\"," +
                                         $"\"typePurchase\":\"{typePurchase}\"," +
                                         $"\"quantityBooks\":{quantityBooks}}}"
                                        )
                                       
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
