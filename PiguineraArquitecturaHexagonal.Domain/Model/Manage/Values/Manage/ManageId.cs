

using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Manage
{
    public class ManageId : Identity
    {
        public ManageId() : base() { }

        public ManageId(string uuid) : base(uuid) { }

        public static ManageId of(string uuid)
        {
            return new ManageId(uuid);
        }
    }
}
