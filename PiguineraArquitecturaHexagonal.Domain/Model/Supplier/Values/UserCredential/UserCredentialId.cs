

using PandemyLagacyDDD.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.UserCredential
{
    public class UserCredentialId : Identity
    {
        public UserCredentialId() : base() { }

        public UserCredentialId(string uuid) : base(uuid) { }

        public static UserCredentialId Of(string uuid)
        {
            return new UserCredentialId(uuid);
        }
    }
}
