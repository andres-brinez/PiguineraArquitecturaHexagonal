namespace PiguineraArquitecturaHexagonal.Infrastructure.API.DataTransferObject.Output
{
    public class QuotesOutputDTO
    {
        public List<InnerQuoteInfo> QuotesInformation { get; set; }
        public decimal TotalPrice { get; set; }

        public QuotesOutputDTO(List<InnerQuoteInfo> innerQuoteInfo, decimal totalPrice)
        {
            QuotesInformation = innerQuoteInfo;
            TotalPrice = totalPrice;
        }
    }

    public class InnerQuoteInfo
    {
        public string IdSupplier { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public string BookType { get; set; }
        public double Discount { get; set; }
        public double UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
