
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PiguineraArquitecturaHexagonal.Domain.Generic
{
    public abstract class DomainEvent
    {
        public DateTime Moment { get;  set; }
        public int Version { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string UUID { get;  set; }
        public string Type { get;  set; }
        public string AggregateName { get; set; }
        public string EventBody { get; set; }
        // body, informacion del libro para obtenerlo
        
        public string AggregateId{ get; set; }

       
        public DomainEvent(string type,  string body)
        {

            Type = type;
            Moment = DateTime.Now;
            UUID = Guid.NewGuid().ToString();
            Version = 1;
            AggregateName = string.Empty;
            AggregateId = string.Empty;
            EventBody = body;
        }

        
    }
}