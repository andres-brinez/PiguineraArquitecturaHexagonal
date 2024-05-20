

using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Application.Generic
{
    public interface IInitialCommandUseCase<T> where T : InitialCommand
    {
        //Task<object> Execute(T command);
        Task<List<DomainEvent>> Execute(T command);


    }
}