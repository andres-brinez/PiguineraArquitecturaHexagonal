using Newtonsoft.Json;

namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Data
{
    public class BookData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("bookType")]
        public string BookType { get; set; }

        [JsonProperty("unitPrice")]
        public float UnitPrice { get; set; }

        [JsonProperty("discount")]
        public float Discount { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
