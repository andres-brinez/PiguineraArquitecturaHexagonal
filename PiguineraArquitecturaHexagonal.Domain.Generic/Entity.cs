
namespace PandemyLagacyDDD.Domain.Generic
{
    public class Entity<I> where I : Identity
    {

        public I Id { get; private set; }

        public Entity(I id)
        {
            this.Id = id;
        }

        public I identity()
        {
            return Id;
        }

        public override bool Equals(object? obj)
        {
            return Id.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}