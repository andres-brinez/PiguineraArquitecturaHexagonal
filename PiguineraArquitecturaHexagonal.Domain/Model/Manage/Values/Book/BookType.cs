using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book
{

    public enum TypeBook
    {
        BOOK,
        NOVEL,
    }
    public class BookType: IValueObject<TypeBook> 
    {
        public TypeBook color { get; }

        public BookType(TypeBook value)
        {
            this.color = value;
        }

        public static BookType Of(TypeBook value)
        {
            return new BookType(value);
        }

        public TypeBook Value()
        {
            return color;
        }

    }
}
