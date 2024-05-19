using PiguineraArquitecturaHexagonal.Domain.Generic;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.QuoteInformation
{
    public class QuoteId : Identity
    {
        public QuoteId() : base() { }

        public QuoteId(string uuid) : base(uuid) { }

        public static QuoteId of(string uuid)
        {
            return new QuoteId(uuid);
        }
    }
}
