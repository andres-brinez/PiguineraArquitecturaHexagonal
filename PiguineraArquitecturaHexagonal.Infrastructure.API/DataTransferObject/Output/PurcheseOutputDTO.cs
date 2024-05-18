using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;

namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Output
{
    public class PurcheseOutputDTO
    {
        public string IdSupplier { get; set; }
        public List<BookDataPurchese> Books { get; set; }
        public string TotalPrice { get; set; }
        public string TypePurchase { get; set; }
        public int QuantityBooks { get; set; }

        public PurcheseOutputDTO(string idSupplier, List<BookDataPurchese> books, string totalPrice, string typePurchase, int quantityBooks)
        {
            IdSupplier = idSupplier;
            Books = books;
            TotalPrice = totalPrice;
            TypePurchase = typePurchase;
            QuantityBooks = quantityBooks;
        }
    }

    public class BookDataPurchese
    {
        public string IdSupplier { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public string BookType { get; set; }
        public float Discount { get; set; }
        public float UnitPrice { get; set; }
        public float TotalPrice { get; set; }

        public BookDataPurchese(string idSupplier, string title, int quantity, string bookType, float discount, float unitPrice, float totalPrice)
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


}
