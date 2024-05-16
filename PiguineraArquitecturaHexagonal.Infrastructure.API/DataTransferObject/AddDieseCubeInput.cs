namespace PiguineraArquitecturaHexagonal.Api.DataTransferObject
{
    public class AddDieseCubeInput
    {
        public int Quantity { get; set; }

        public AddDieseCubeInput(int quantity)
        {
            Quantity = quantity;
        }
    }
}
