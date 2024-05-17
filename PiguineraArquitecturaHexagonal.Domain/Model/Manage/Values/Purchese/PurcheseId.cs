


using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Purchese
{
    public class PurchaseId : Identity
    {
        public PurchaseId() : base() { }

        public PurchaseId(string uuid) : base(uuid) { }

        public static PurchaseId of(string uuid)
        {
            return new PurchaseId(uuid);
        }
    }
}
