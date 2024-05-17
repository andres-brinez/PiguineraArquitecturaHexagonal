namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Output
{
    public class BookOutputDTO
    {

        public string Title { get; set; }
        public string Type { get; set; }
        public float UnitPrice { get; set; }
        public float TotalPrice { get; set; }
        public int Cuantity { get; set; }
        public string Discount { get; set; }

        public BookOutputDTO()
        {

        }
        public BookOutputDTO(string title, string type, float price, float discount, int cuantity)
        {

            Title = title;
            Type = type;

            UnitPrice = (float)System.Math.Round(price, 2);
            Cuantity = cuantity;
            TotalPrice = (float)System.Math.Round(UnitPrice * Cuantity, 2);

            float discountPercentage = (float)System.Math.Round(discount * 100, 0);
            Discount = discountPercentage.ToString() + "%";
            Cuantity = cuantity;
        }

    }
}