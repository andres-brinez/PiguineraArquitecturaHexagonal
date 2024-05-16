using PiguineraArquitecturaHexagonal.Domain.Generic;


namespace PiguineraArquitecturaHexagonal.Application.Generic
{
    public interface ICommandUseCase<T, I> where T : Command<I> where I : Identity
    {
        Task<List<DomainEvent>> Execute(T command);
    }
}