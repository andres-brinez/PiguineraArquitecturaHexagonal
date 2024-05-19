namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Output
{
    public class BudgetOutputDTO
    {

        public List<BookDataPurchese> Books { get; set; }
        public string BudgetValueFinal { get; set; }

        public BudgetOutputDTO(List<BookDataPurchese> books, string budgetValueFinal)
        {
            Books = books;
            BudgetValueFinal = budgetValueFinal;
        }




    }


}
