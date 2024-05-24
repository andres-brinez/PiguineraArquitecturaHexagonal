

using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Purchese;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.QuoteInformation;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities
{
    public class QuoteInformation : Entity<QuoteInformationId>
    {

        private List<Book> Books;
        private QuantityBooks QuantityBooks;
        private Values.Purchese.TotalPrice TotalPrice;
        private TypePurchase TypePurchase;

        public QuoteInformation(QuoteInformationId id) : base(id)
        {
        }

        public QuoteInformation(List<Book> books) : base(new QuoteInformationId())
        {
            QuantityBooks = new QuantityBooks(books);
            TypePurchase = new TypePurchase(QuantityBooks.Value());
            Books = Entities.Purchese.CalculatePurcheseValue(books);
            TotalPrice = new Values.Purchese.TotalPrice(this.Books);
        }

        public List<Book> GetBooks()
        {
            return Books;
        }

        public float GetTotalPrice()
        {
            return TotalPrice.Value();
        }

        public int GetQuantityBook()
        {
            return QuantityBooks.Value();
        }

        public String GetTypePurchase()
        {
            return TypePurchase.Value();
        }

                                            
        public override string ToString()
        {
            var booksJson = string.Join(", ", Books.Select(b => $"{{\"IdSupplier\":\"{b.IdSupplier.Value()}\"," +
                                                                                    $"\"Title\":\"{b.Title.Value()}\"," +
                                                                                    $"\"Quantity\":{b.Quantity.Value()}," +
                                                                                    $"\"BookType\":\"{b.BookType.Value()}\"," +
                                                                                    $"\"Discount\":{b.Discount.Value()}," +
                                                                                    $"\"UnitPrice\":{b.UnitPrice.Value()}" +
                                                                                    $",\"TotalPrice\":{b.GetTotalPrice()}}}"));

            var quoteInfoJson = $"{{\"Quantity\":{QuantityBooks.Value()},\"TotalPrice\":{TotalPrice.Value()},\"TipePurchese\":\"{TypePurchase.Value()}\"}}";

            return $"{{\"Books\":[{booksJson}],\"QuoteInfo\":{quoteInfoJson}}}";

        }


    }

}
