
using PandemyLagacyDDD.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Information;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Entities
{
    public class Information:Entity<InformationId>
    {
        private Name Name;
        private Address Address;
        private Phone PhoneNumber;
        private Seniority Seniority;
        private Status Status;

        public Information(InformationId id) : base(id)
        {
        }

        public Information(string name, string address, string numberPhone) : base(new InformationId())
        {
            Name = new Name(name);
            Address = new Address(address);
            PhoneNumber = new Phone(numberPhone);
            Seniority = new Seniority(0);
            Status = new Status(false);
        }

        public static Information Of(string name, string address, string numberPhone)
        {
            return (new Information( name,  address, numberPhone));
        }

        public string GetName()
        {
            return Name.Value(); 
        }

        public string GetAddress()
        {
            return Address.Value(); 
        }

        public string GetPhoneNumber() 
        {
            
            return PhoneNumber.Value(); 
        }

        public int GetSeniority()
        {
            return Seniority.Value(); 
        }

        public bool GetStatus()
        {
            return Status.Value();
        }

        public  void CalculateSeniority(DateTime registerDate)
        {
            TimeSpan tiempoTranscurrido = DateTime.UtcNow - registerDate;
            int añosTranscurridos = (int)(tiempoTranscurrido.Days / 365.25); // Años transcurridos, considerando años bisiestos

            Seniority = new Seniority(añosTranscurridos);

        }

        public void chageStatus(bool status)
        {
            
                Status= new Status(status);  
            
        }

    }
}
