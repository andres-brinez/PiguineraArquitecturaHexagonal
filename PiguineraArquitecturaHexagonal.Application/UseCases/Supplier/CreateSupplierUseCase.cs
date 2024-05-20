using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Commands;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Entities;
using System.Reactive.Linq;


namespace PiguineraArquitecturaHexagonal.Application.UseCases.Supplier
{
    public class CreateSupplierUseCase : IInitialCommandUseCase<CreateSupplierCommnad>
    {
        private readonly IEventsRepository _repository;

        public CreateSupplierUseCase(IEventsRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<DomainEvent>> Execute(CreateSupplierCommnad command)
        {

            var supplier = new SupplierAgregateRoot(command.Email,command.Password);

            var domainEvents = supplier.GetUncommittedChanges().ToList();

             domainEvents.
                 ToObservable()
                .Subscribe( async e =>
                {
                    try
                    {
                       await _repository.Save(e);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al procesar eventos de dominio: {0}", ex.Message);
                    }
                });

            supplier.MarkAsCommitted();
            return domainEvents;
        }


    }
}