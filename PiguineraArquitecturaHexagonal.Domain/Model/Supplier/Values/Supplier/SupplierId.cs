using PiguineraArquitecturaHexagonal.Domain.Generic;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Supplier
{
    public class SupplierId : Identity
    {
        public SupplierId() : base() { }

        public SupplierId(string uuid) : base(uuid) { }

        public static SupplierId Of(string uuid)
        {
            return new SupplierId(uuid);
        }
    }
}
