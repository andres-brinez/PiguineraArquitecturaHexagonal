
using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Budget;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities
{
    public class Budget : Entity<BudgetId>
    {
        private List<Book> Books;
        private BudgetValue BudgetValue;
        private BudgetValueFinal BudgetValueFinal;

        public Budget(BudgetId id) : base(id)
        {
        }

        public Budget(List<Book> books, Decimal budgetValue) : base(new BudgetId())
        {
            BudgetValue = new BudgetValue(budgetValue);
            Books = CalculateBudget(books);

   
        }

        public List<Book> GetBooks()
        {
            return Books;
        }

        public decimal GetBudgetValue()
        {
            return BudgetValue.Value();
        }

        public decimal GetBudgetValueFinal()
        {
            return BudgetValueFinal.Value();
        }

        public List<Book> CalculateBudget(List<Book> books)
        {
          
            books = books.OrderByDescending(book => book.Discount.Value()).ThenBy(item => item.UnitPrice.Value()).ToList();
            List<Book> booksAvailable = SelectBooksWithinBudget(books, (double)BudgetValue.Value());

            return booksAvailable;
        }

        private List<Book> SelectBooksWithinBudget(List<Book> books,  double totalBudgetAvailable)
        {

            Console.WriteLine(totalBudgetAvailable);

            List<Book> booksAvailable = new List<Book>();
            List<Book> booksPurchese = new List<Book>();

            bool hasBook = false;
            bool hasNovel = false;


            foreach (var originalBook in books)
            {

                Book bookClone = (Book)originalBook.Clone();
                bookClone.Quantity =new Values.Book.Quantity(0);

                while (totalBudgetAvailable > originalBook.GetUnitPrice())
                {

            
                    bool shouldAddBook = originalBook.GetBookType().ToString() == TypeBook.NOVEL.ToString() && !hasNovel ||
                                         originalBook.GetBookType().ToString() == TypeBook.BOOK.ToString() && !hasBook ||
                                         hasBook && hasNovel;

                    if (shouldAddBook)
                    {
                   
                        bookClone.Quantity = new Quantity(bookClone.GetQuantity()+1);

                        totalBudgetAvailable -= originalBook.GetUnitPrice();

                        ValidateTypeBook(originalBook, ref hasBook, ref hasNovel);
                    }
                    else
                    {
                        break;
                    }

                }

                if (bookClone.GetQuantity() > 0)
                {
                    booksAvailable.Add(bookClone);
                }

            }

            this.BudgetValueFinal = new BudgetValueFinal((decimal)totalBudgetAvailable);
            booksPurchese = Purchese.CalculatePurcheseValue(booksAvailable);
            return booksPurchese;
        }



        private void ValidateTypeBook(Book book, ref bool hasBook, ref bool hasNovel)
        {
            if (book.GetBookType().ToString() == TypeBook.NOVEL.ToString())
            {
                hasNovel = true;
            }
            else if (book.GetBookType().ToString() == TypeBook.BOOK.ToString())
            {

                hasBook = true;
            }
        }

    }

}