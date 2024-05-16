using PandemyLagacyDDD.Domain.Generic;


namespace PandemyLagacyDDD.Application.Generic
{
    // Marca los casos de usos que nacen a partir del lanzamiento de un evento 
    public interface IEventUseCase<T> where T : DomainEvent
    {
        List<DomainEvent> Execute(T domainEvent);
    }
}