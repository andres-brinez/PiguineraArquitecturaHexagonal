using MongoDB.Driver;
using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Domain.Generic;


namespace PiguineraArquitecturaHexagonal.Infrastructure.Persistence
{
    public class EventsRepository : IEventsRepository
    {
        private readonly IMongoCollection<Event> _eventRepository;

        public EventsRepository(IMongoCollection<Event> repository)
        {
            _eventRepository = repository;
        }

        public async Task<List<DomainEvent>> FindByAggregateId(string aggregateId)
        {
            var cursor = _eventRepository.FindAsync((eve) => eve.AggregateId.Equals(aggregateId)).Result;
            var events = await cursor.ToListAsync();
            return events.Select(e => e as DomainEvent).ToList();
        }

        public async Task<List<DomainEvent>> Save(DomainEvent domainEvent)
        {
            var @event = new Event(domainEvent.Type,domainEvent.EventBody)
            {
                AggregateId = domainEvent.AggregateId,
                AggregateName = domainEvent.AggregateName,
                Moment = domainEvent.Moment,
                Type = domainEvent.Type,
                UUID = domainEvent.UUID,
                Version = domainEvent.Version,
                EventBody = domainEvent.EventBody
            };
            _eventRepository.InsertOne(@event);

            return await FindByAggregateId(domainEvent.AggregateId);
        }

        public async Task<DomainEvent> GetById(string id)
        {
            var @event = await _eventRepository.Find(e => e.UUID == id).FirstOrDefaultAsync();

            if (@event == null)
                return null;

            return @event;
        }




    }
}