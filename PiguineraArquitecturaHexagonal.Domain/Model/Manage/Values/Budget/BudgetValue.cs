
using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Budget
{
    public class BudgetValue : IValueObject<decimal>
    {
        private readonly decimal _value;
        public BudgetValue(decimal value)
        {
            if (value<0 )
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"El valor del presupuesto debe ser mayor a {0}.");
            }

            _value = value;
        }

        public static BudgetValue Of(decimal value)
        {
            return new BudgetValue(value);
        }

        public decimal Value() 
        {
            return _value;
        }

    }
}
