namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Output
{
    public class BudgetOutputDTO
    {

        public List<BookDataPurchese> QuotesInformation { get; set; }
        public string BudgetValueFinal { get; set; }

        public BudgetOutputDTO(List<BookDataPurchese> books, string budgetValueFinal)
        {
            QuotesInformation = books;
            BudgetValueFinal = budgetValueFinal;
        }




    }


}
