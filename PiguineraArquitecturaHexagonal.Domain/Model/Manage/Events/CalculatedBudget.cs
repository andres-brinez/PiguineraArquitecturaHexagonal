
using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Events.Configuration;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Events
{
    public class CalculatedBudget : DomainEvent
    {
        public string IdSupplier;
        public List<Entities.Book> Books;
        public decimal BudgetValue;
        public decimal BudgetValueFinal;

        public CalculatedBudget(string idSupplier,
                                 List<Book> books,
                                 decimal budgetValue,
                                 decimal budgetValueFinal
                                ) :
                                    base(EventsEnumManage.CALCULATEDBUDGET.ToString(),
                                         $"{{\"IdSupplier\":\"{idSupplier}\"," +
                                          //$"\"Books\":\"{JsonConvert.SerializeObject(books)}\"," +
                                          $"\"Books\":[{string.Join(",", books.Select(book => book.ToString()))}]," +
                                          $"\"budgetValue\":\"{budgetValue}\"," +
                                          $"\"budgetValueFinal\":{ budgetValueFinal}}}" 
                                        )
        {
            IdSupplier = idSupplier;
            Books = books;
            BudgetValue = budgetValue;
            BudgetValueFinal = budgetValueFinal;
        }
    }
}
