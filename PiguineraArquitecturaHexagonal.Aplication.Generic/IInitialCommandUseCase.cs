

using PandemyLagacyDDD.Domain.Generic;

namespace PandemyLagacyDDD.Application.Generic
{
    public interface IInitialCommandUseCase<T> where T : InitialCommand
    {
        Task<List<DomainEvent>> Execute(T command);
    }
}