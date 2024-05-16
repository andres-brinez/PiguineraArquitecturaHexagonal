using PiguineraArquitecturaHexagonal.Domain.Generic;


namespace PiguineraArquitecturaHexagonal.Infrastructure.Persistence
{
    public class Event : DomainEvent
    {
        public Event(string type, string body) : base(type,body)
        {
        }
    }
}