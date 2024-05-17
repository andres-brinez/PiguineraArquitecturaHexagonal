using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book
{
    public class Title : IValueObject<string>
    {
        private readonly string _title;

        public Title(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("El título no puede ser nulo o vacío.", nameof(title));
            }

            _title = title;
        }

        public static Title Of(string title)
        {
            return new Title(title);
        }

        public string Value() 
        {
            return _title;
        }

    }

}
