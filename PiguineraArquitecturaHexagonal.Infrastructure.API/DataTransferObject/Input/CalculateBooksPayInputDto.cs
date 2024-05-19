namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Input
{
    public class CalculateBooksPayInputDto
    {
       
        public List<PurcheseInputDto> InformationBook { get; set; }
        public string IdSupplier { get; set; }

        public CalculateBooksPayInputDto(List<PurcheseInputDto> informationBook, string idsupplier)
        {
            InformationBook = informationBook;
            IdSupplier = idsupplier;
        }



    }
}
