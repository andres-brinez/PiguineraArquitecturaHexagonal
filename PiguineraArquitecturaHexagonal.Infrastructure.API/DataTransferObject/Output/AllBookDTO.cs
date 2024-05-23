using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;

namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Output
{
    public class AllBookDTO
    {
        public List<BookInformation> Books { get; set;} = new List<BookInformation>();

        public AllBookDTO(List<BookInformation> books)
        {
            Books = books;
        }
    }

    public class BookInformation
    {
        public string Id { get; set; }
        public string EmailSupplier { get; set; }
        public string Title { get; set; }
        public string BookType { get; set; }
        public decimal UnitPrice { get; set; }
        public float Discount { get; set; }

        public BookInformation(string id, string emailSupplier, string title, string bookType, decimal unitPrice, float discount)
        {
            Id = id;
            EmailSupplier = emailSupplier;
            Title = title;
            BookType = bookType;
            UnitPrice = unitPrice;
            Discount = discount;
        }

        public override string? ToString()
        {
            return $"Id: {Id}, Title: {Title}, BookType: {BookType}, UnitPrice: [{UnitPrice}]";
        }
    }
}
