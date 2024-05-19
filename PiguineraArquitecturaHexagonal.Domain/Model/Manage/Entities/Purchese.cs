
using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Purchese;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities
{
    public class Purchese : Entity<PurchaseId>
    {

        private List<Book> Books;
        private Values.Purchese.TotalPrice TotalPrice;
        private QuantityBooks QuantityBooks;
        private TypePurchase TypePurchase;


        public Purchese(PurchaseId id) : base(id)
        {
        }

        public Purchese(List<Book> books) : base(new PurchaseId())
        {
            //QuotesInformation = books;

            QuantityBooks = new QuantityBooks(books);
            TypePurchase = new TypePurchase(QuantityBooks.Value());
            Books= CalculatePurcheseValue(books);
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

        // Calcula el valor de compra de una lista de libros (List<Book>), aplicando diferentes estrategias de precios según la cantidad de cada libro.
        public static List<Book> CalculatePurcheseValue(List<Book> books)
        {
            int countBooks = 0;
            List<Book> booksResult = new List<Book>();


            foreach (var originalBook in books)
            {
                //Para cada libro, se crea dos clones: retailBook y bulkBook.
                Book retailBook = (Book)originalBook.Clone();
                retailBook.Quantity=new Quantity(0);
                retailBook.Discount = new Discount(0);

                Book bulkBook = (Book)originalBook.Clone();
                bulkBook.Quantity = new Quantity(0);
                bulkBook.Discount = new Discount(0);


                for (int j = 0; j < originalBook.GetQuantity(); j++)
                {
                    if (countBooks > 9)
                    {
                        bulkBook.Quantity =  new Quantity((bulkBook.GetQuantity() + 1));

                    }
                    else
                    {
                        retailBook.Quantity= new Quantity((retailBook.GetQuantity() + 1));

                    }

                    countBooks++;
                }

                ApplyBulkDecrease(bulkBook);
                ApplyRetailIncrease(retailBook);

                if (retailBook.GetQuantity() > 0) booksResult.Add(retailBook);
                if (bulkBook.GetQuantity() > 0) booksResult.Add(bulkBook);

            }

            return booksResult;

        }
       
        public static void ApplyRetailIncrease(Book book)
        {
            const float RETAIL_INCREASE = 1.02f;

            book.UnitPrice = new UnitPrice(Convert.ToInt32(book.GetUnitPrice()* RETAIL_INCREASE));
            book.CalculaTotalPrice();
        }

        private static void ApplyBulkDecrease(Book book)
        {
            const float BULK_DECREASE_PER_UNIT = 0.15f;
            var amountDiscount = (double)book.GetUnitPrice() * BULK_DECREASE_PER_UNIT;
           
            book.UnitPrice = new UnitPrice(book.GetUnitPrice()-amountDiscount);
            book.Discount = new Discount((decimal)BULK_DECREASE_PER_UNIT);
            book.CalculaTotalPrice();

        }

        public override string ToString()
        {
            return $"QuotesInformation: {string.Join(", ", Books.Select(b => b.ToString()))}, " +
                   $"Total Price: {TotalPrice.Value}, " +
                   $"Quantity: {QuantityBooks.Value}, " +
                   $"Type Purchase: {TypePurchase.Value}";
        }


    }
}
