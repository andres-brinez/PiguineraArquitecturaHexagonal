
using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Purchese;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities
{
    public class Purchese : Entity<PurchaseId>
    {

        private List<Book> Books;
        private TotalPrice TotalPrice;
        private QuantityBook QuantityBook;
        private TypePurchase TypePurchase;


        public Purchese(PurchaseId id) : base(id)
        {
        }

        public Purchese(List<Book> books) : base(new PurchaseId())
        {
            Books = books;

            TotalPrice= new TotalPrice(Books);
            QuantityBook = new QuantityBook(Books);
            TypePurchase = new TypePurchase(QuantityBook.Value());

        }

        public List<Book> GetBooks()
        {
            return new List<Book>(Books); 
        }

        public float GetTotalPrice()
        {
            return TotalPrice.Value(); 
        }

        public int GetQuantityBook()
        {
            return QuantityBook.Value(); 
        }

        public String GetTypePurchase()
        {
            return TypePurchase.Value();
        }



    }
}
