namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Input
{
    public class CalculateBooksQuotesInputDto
    {
       
        public List<List<PurcheseInputDto>> InformationBooks { get; set; }
        public string IdSupplier { get; set; }

        public CalculateBooksQuotesInputDto(List<List<PurcheseInputDto>> informationBooks, string idSupplier)
        {
            InformationBooks = informationBooks;
            IdSupplier = idSupplier;
        }
    }
}
