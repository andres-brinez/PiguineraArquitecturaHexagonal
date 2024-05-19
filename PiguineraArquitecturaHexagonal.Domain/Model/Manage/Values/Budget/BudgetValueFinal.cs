

using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Budget
{
    public class BudgetValueFinal : IValueObject<decimal>
    {
        private readonly decimal _value;
        public BudgetValueFinal(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"El valor del presupuesto final  no debe ser menor a  {0}.");
            }

            _value = value;
        }

        public static BudgetValueFinal Of(decimal value)
        {
            return new BudgetValueFinal(value);
        }

        public decimal Value() // Explicit implementation of IValueObject's Value() method
        {
            return _value;
        }

        // **Equals and GetHashCode methods are not implemented.**
    }

}
