namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Input
{
    public class BudgetInputDTO
    {
        public List<string> IdBooks { get; set; }
        public decimal Budget { get; set; }

        public BudgetInputDTO()
        {
        }

        public BudgetInputDTO(List<string> idsBooks, decimal budget)
        {
            IdBooks = idsBooks;
            Budget = budget;
        }
    }
}
