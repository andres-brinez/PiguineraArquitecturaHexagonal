

using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;

namespace PiguineraArquitecturaHexagonal.Application.UseCases.Manage.Book
{
    public class CreateBookUseCase : IInitialCommandUseCase<CreateBookCommand>
    {
        private readonly IEventsRepository _repository;

        public CreateBookUseCase(IEventsRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<DomainEvent>> Execute(CreateBookCommand command)
        {

            var manage = new ManageAgregationRoot(command.idSupplier);
            manage.CreateBook(command.idSupplier, command.seniority, command.title, command.quantity, command.bookType, command.originalPrice);

            var domainEvents = manage.GetUncommittedChanges().ToList();

            domainEvents.ForEach(async (DomainEvent domainEvent) =>
            {
                await _repository.Save(domainEvent);
            });

            manage.MarkAsCommitted();
            return domainEvents;
        }


    }
}