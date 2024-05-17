

using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Purchese
{
    public class TotalPrice : IValueObject<float>
    {
        private readonly float _totalPrice;

        public TotalPrice(List<Entities.Book> books)
        {
            if (books == null)
            {
                throw new ArgumentOutOfRangeException(nameof(books), "La lista de libros no puede ser null");
            }

            _totalPrice = (float)System.Math.Round(books.Sum(item => item.GetUnitPrice() * item.GetQuantity()), 2);
        }

        public static TotalPrice Of(List<Entities.Book> books)
        {
            return new TotalPrice(books);
        }

        public float Value() 
        {
            return _totalPrice;
        }


    }

}
