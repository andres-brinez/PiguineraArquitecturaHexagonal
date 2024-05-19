using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Events;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Events.Configuration;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Manage;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Supplier;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities
{
    public class ManageAgregationRoot : AggregateRoot<ManageId>
    {

        public SupplierId SupplierId;
        public Book Book;
        public Purchese Purchese;
        public Budget Budget;

        public ManageAgregationRoot(ManageId identity) : base(identity)
        {
        }

        public ManageAgregationRoot(string supplierId) : base(new ManageId())
        {
            Subscribe(new ManageEventChange(this));
            SupplierId = new SupplierId(supplierId);

        }

        public void  CreateBook(string supplierId, int seniority, string title, int quantity, TypeBook bookType, int originalPrice)
        {

            Book = new Book(supplierId, seniority, title, quantity, bookType, originalPrice);

            AppendEvent(new CreatedBook(supplierId,
                                        Book.GetSeniority(),
                                        Book.GetTitle(),
                                        Book.GetQuantity(),
                                        Book.GetBookType(),
                                        Book.GetOriginalPrice(),
                                        Book.GetDiscount(),
                                        Book.GetUnitPrice(),
                                        Book.GetTotalPrice()));
        }

        public void CalculatPayment ( string supplierId, List<string> booksId, List<Book> books)
        {
            Purchese purchese = new Purchese(books);
            AppendEvent(new CalculatedPayment( supplierId,
                                               booksId,
                                               purchese.GetBooks(),
                                               purchese.GetTotalPrice(),
                                               purchese.GetTypePurchase(),
                                               purchese.GetQuantityBook()
                                              ));

        }


        public void CalculateBudget(string supplierId,List<Book> books, decimal budgetValue, decimal budgetValueFinal)
        {
            AppendEvent(new CalculatedBudget(supplierId,
                                               books,
                                               budgetValue,
                                               budgetValueFinal
                                              ));

        }



    }
}
