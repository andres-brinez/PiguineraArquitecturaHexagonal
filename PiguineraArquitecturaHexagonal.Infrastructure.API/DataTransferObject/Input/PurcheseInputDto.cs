namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Input
{
    public class PurcheseInputDto
    {
        public string IdBook { get; set; }
        public int Quantity { get; set; }


        public PurcheseInputDto() { }

        public PurcheseInputDto(string id, int cuantity)
        {
            IdBook = id;
            Quantity = cuantity;
        }

    }
}
