

namespace PandemyLagacyDDD.Domain.Generic
{
    public interface IValueObject<T>
    {
        T Value();
    }
}