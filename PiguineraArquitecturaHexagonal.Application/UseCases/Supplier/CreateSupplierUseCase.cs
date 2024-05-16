using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Commands;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Entities;


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

            domainEvents.ForEach(async (DomainEvent domainEvent) =>
            {
                await _repository.Save(domainEvent);
            });

            supplier.MarkAsCommitted();
            return domainEvents;
        }


    }
}