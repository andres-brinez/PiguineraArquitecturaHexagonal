using PandemyLagacyDDD.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.UserCredential;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Entities
{
    public class UserCredential : Entity<UserCredentialId>
    {

        private Email Email;
        private RegistrationDate RegistrationDate;
        private Password Password;

        public UserCredential(UserCredentialId id) : base(id)
        {
        }

        public UserCredential(string email, string password ) : base(new UserCredentialId())
        {
            Email =new Email(email);
            Password =new Password(password);
            RegistrationDate = new RegistrationDate();
        }


        public static UserCredential Of(string email, string password)
        {
            return (new UserCredential( email,  password));
        }

        public String GetEmail()
        {
            return Email.Value();
        }

        public DateTime GetRegistrationDate()
        {
            return RegistrationDate.Value();
        }
    }
}
