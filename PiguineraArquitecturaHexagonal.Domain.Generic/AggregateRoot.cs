

using System.Diagnostics.Tracing;
using System.Security.Principal;

namespace PandemyLagacyDDD.Domain.Generic
{
    public abstract class AggregateRoot<I> : Entity<I> where I : Identity
    {

        private readonly ChangeEventSubscriber _changeEventSubscriber;

        public AggregateRoot(I identity) : base(identity)
        {
            _changeEventSubscriber = new();
        }
        public List<DomainEvent> GetUncommittedChanges()
        {
            return _changeEventSubscriber.Events.ToList();
        }

        public void MarkAsCommitted()
        {
            _changeEventSubscriber.Events.Clear();
        }

        protected void Subscribe(EventChange eventChange)
        {
            _changeEventSubscriber.Subscribe(eventChange);
        }

        protected void Apply(DomainEvent domainEvent)
        {
            _changeEventSubscriber.Apply(domainEvent);
        }

        protected Action AppendEvent(DomainEvent domainEvent)
        {
            string aggreateName = this.GetType().Name.ToLower();
            domainEvent.AggregateName = aggreateName;
            domainEvent.AggregateId = Id.Value();
            return _changeEventSubscriber.Append(domainEvent);
        }
    }
}