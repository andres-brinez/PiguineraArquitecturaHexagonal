

using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands
{
    public class CalculateBudgetCommand : InitialCommand
    {

        public string IdSupplier;
        public List<Book> Books;
        public decimal BudgetValue;

        public CalculateBudgetCommand(string idSupplier, List<Book> books, decimal budgetValue)
        {
            IdSupplier = idSupplier;
            Books = books;
            BudgetValue = budgetValue;
        }
    }
}
