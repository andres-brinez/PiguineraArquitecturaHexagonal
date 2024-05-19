using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Events.Configuration;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Events
{
    public class CalculatedQuote : DomainEvent
    {
        public string IdSupplier;
        public List<QuoteInformation> QuotesInformation;
        public float TotalPrice;
        public List<List<Book>> Books;


        public CalculatedQuote(     string idSupplier,
                                    List<QuoteInformation> quotesInformation,
                                    List<List<Book>> books,
                                    float totalPrice
                                ) :
                                    base(EventsEnumManage.CALCULATEDQUOTE.ToString(),
                                         $"{{\"IdSupplier\":\"{idSupplier}\"," +
                                         $"\"QuotesInformation\":[{string.Join(",", quotesInformation.Select(quote => quote.ToString()))}]," +
                                         $"\"totalPrice\":{totalPrice} }}"
                                        )

        {
            IdSupplier = idSupplier;
            QuotesInformation = quotesInformation;
            TotalPrice = totalPrice;
            Books = books;


        }
    }

}
