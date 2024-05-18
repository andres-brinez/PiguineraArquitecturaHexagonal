

using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands
{
    public class CalculatePaymentCommand : InitialCommand
    
    {
        public string IdSupplier;
        public List<string> BooksId;
        public List<Entities.Book> Books;
        

        public CalculatePaymentCommand( string idSupplier,
                                        List<string> booksId,
                                        List<Book> books
                                        )
        {
            IdSupplier = idSupplier;
            BooksId = booksId;
            Books = books;
            
        }
    }
}
