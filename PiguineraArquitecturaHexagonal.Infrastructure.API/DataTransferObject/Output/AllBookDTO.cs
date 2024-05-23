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
        public string Title { get; set; }
        public string BookType { get; set; }
        public decimal UnitPrice { get; set; }

        public BookInformation(string id, string title, string bookType, decimal unitPrice)
        {
            Id = id;
            Title = title;
            BookType = bookType;
            UnitPrice = unitPrice;
        }

        public override string? ToString()
        {
            return $"Id: {Id}, Title: {Title}, BookType: {BookType}, UnitPrice: [{UnitPrice}]";
        }
    }
}
