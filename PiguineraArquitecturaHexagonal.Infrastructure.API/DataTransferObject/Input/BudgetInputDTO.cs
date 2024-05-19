namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Input
{
    public class BudgetInputDTO
    {
        public string IdSupplier { get; set; }
        public List<string> IdBooks { get; set; }
        public decimal Budget { get; set; }

        public BudgetInputDTO()
        {
        }

        public BudgetInputDTO(string idSupplier, List<string> idBooks, decimal budget)
        {
            IdSupplier = idSupplier;
            IdBooks = idBooks;
            Budget = budget;
        }
    }
}
