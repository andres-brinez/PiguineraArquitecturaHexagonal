

using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book
{
    public class BookId : Identity
    {
        public BookId() : base() { }

        public BookId(string uuid) : base(uuid) { }

        public static BookId Of(string uuid)
        {
            return new BookId(uuid);
        }
    }
}
