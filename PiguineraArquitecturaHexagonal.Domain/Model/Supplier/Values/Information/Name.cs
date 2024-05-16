
using PandemyLagacyDDD.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Information
{
    public class Name : IValueObject<string>
    {
        private readonly string NameValue;

        public Name(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(name));
            }
          
            NameValue = name;
        }

        public static Name Of(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("El nombre completo no puede estar vacío.", nameof(name));
            }

           
            return new Name(name);
        }


        public string Value()
        {
            return NameValue; 
        }

    }
}