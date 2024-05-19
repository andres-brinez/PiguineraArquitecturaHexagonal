using PiguineraArquitecturaHexagonal.Domain.Generic;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.QuoteInformation
{
    public class QuoteInformationId : Identity
    {
        public QuoteInformationId() : base() { }

        public QuoteInformationId(string uuid) : base(uuid) { }

        public static QuoteInformationId of(string uuid)
        {
            return new QuoteInformationId(uuid);
        }
    }
}
