using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Information
{
    public class InformationId : Identity
    {
        public InformationId() : base() { }

        public InformationId(string uuid) : base(uuid) { }

        public static InformationId of(string uuid)
        {
            return new InformationId(uuid);
        }
    }
}
