namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Input
{
    public class CalculateBookPayDto
    {
       
        public List<PurcheseInputDto> InformationBook { get; set; }
        public string IdSupplier { get; set; }

        public CalculateBookPayDto(List<PurcheseInputDto> informationBook, string idsupplier)
        {
            InformationBook = informationBook;
            IdSupplier = idsupplier;
        }



    }
}
