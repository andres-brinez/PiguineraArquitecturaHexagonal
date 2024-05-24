using Newtonsoft.Json;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;

namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Output
{
    public class QuotesOutputDTO
    {
        public string IdSupplier { get; set; }
        public List<QuoteInformation> QuotesInformation { get; set; }
        public decimal TotalPrice { get; set; }

        public QuotesOutputDTO(string idSupplier, List<QuoteInformation> quotesInformation, decimal totalPrice)
        {
            IdSupplier = idSupplier;
            QuotesInformation = quotesInformation;
            TotalPrice = totalPrice;
        }
    }

    public class QuoteInformation
    {
        public List<BookInfo> Books { get; set; }
        public QuoteInfo QuoteInfo { get; set; }

        public QuoteInformation(List<BookInfo> books, QuoteInfo quoteInfo)
        {
            Books = books;
            QuoteInfo = quoteInfo;
        }


    }
    public class BookInfo
    {
        public string IdSupplier { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public string BookType { get; set; }
        public decimal Discount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public BookInfo(string idSupplier, string title, int quantity, string bookType, decimal discount, decimal unitPrice, decimal totalPrice)
        {
            IdSupplier = idSupplier;
            Title = title;
            Quantity = quantity;
            BookType = bookType;
            Discount = discount;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }
    }

    public class QuoteInfo
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string TipePurchese { get; set; }

        public QuoteInfo(int quantity, decimal totalPrice, string tipePurchese)
        {
            Quantity = quantity;
            TotalPrice = totalPrice;
            TipePurchese = tipePurchese;
        }
    }
}
