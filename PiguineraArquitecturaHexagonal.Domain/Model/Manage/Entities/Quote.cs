

using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Purchese;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.QuoteInformation;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities
{
    public class Quote : Entity<QuoteId>
    {
        private List<QuoteInformation> Quotes = new List<QuoteInformation>();


        private Values.Purchese.TotalPrice TotalPrice= new Values.Purchese.TotalPrice(0);

        public Quote(List<List<Book>> groupsBooks): base (new QuoteId())
        {
            foreach (var groupBooks in groupsBooks)
            {
                
                var quote = new QuoteInformation(groupBooks);

                Quotes.Add(quote);

                
            }

            var totalPriceValue = System.Math.Round(Quotes.Sum(quote => quote.GetTotalPrice()),2);
             TotalPrice = new Values.Purchese.TotalPrice((float)totalPriceValue);

        }

        public List<QuoteInformation> GetQuotes()
        {
            return Quotes;
        }

        public float GetTotalPrice()
        {
            return TotalPrice.Value();
        }

        //public override string ToString()
        //{
          

        //    return
        //         $"{{\"IdSupplier\":[{string.Join(", ", Quotes.Select(q => q.ToString()))}, " +
        //         $"\"TotalPrice\":{GetTotalPrice()}," + "}";
        //}
    }
}
