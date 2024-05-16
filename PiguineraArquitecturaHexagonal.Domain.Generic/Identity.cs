

namespace PandemyLagacyDDD.Domain.Generic
{
    public class Identity : IValueObject<string>
    {
        public readonly string Uuid;


        public Identity()
        {
            this.Uuid = Guid.NewGuid().ToString();
        }


        public Identity(string uuid)
        {

            this.Uuid = uuid;
        }

        public string Value()
        {
            return Uuid;
        }



        public override bool Equals(object? obj)
        {
            return obj is Identity identity &&
                   Uuid.Equals(identity.Uuid);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Uuid);
        }

    }
}