

using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Application.Generic
{
    public interface IInitialCommandUseCase<T> where T : InitialCommand
    {
        Task<List<DomainEvent>> Execute(T command);
    }
}