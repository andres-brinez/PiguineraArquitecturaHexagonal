

using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Purchese
{
    public class TypePurchase : IValueObject<string>
    {
        private readonly string _type;


        public TypePurchase(int quantityBooks)
        {
            if (quantityBooks<0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantityBooks), $"La cantidad en la compra no debe ser negativo");
            }

            _type = quantityBooks <= 0 ? "----" : (quantityBooks < 10 && quantityBooks >= 0 ? "Compra al detal" : "Compra al por mayor");
        }



        public static TypePurchase Of(int quantityBooks)
        {
            return new TypePurchase(quantityBooks);
        }

        public string Value() 
        {
            return _type;
        }

       
    }

}
