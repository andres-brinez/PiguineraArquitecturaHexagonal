using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;

namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Input
{
    public class BookInputDTO
    {
        public string IdProvider { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int OriginalPrice { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }

        public BookInputDTO()
        {
            
        }

        public BookInputDTO(string idProvider, string title, int originalPrice, int quantity, string type)
        {
            IdProvider = idProvider;
            Title = title;
            OriginalPrice = originalPrice;
            Quantity = quantity;
            Type = type;
        }
    }
}
