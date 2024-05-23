

using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;
using System.Reactive.Linq;

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
            manage.CreateBook(command.idSupplier,command.emailSupplier, command.seniority, command.title, command.quantity, command.bookType, command.originalPrice);

            var domainEvents = manage.GetUncommittedChanges().ToList();

            domainEvents
             .ToObservable()
             .Subscribe(async e =>
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

            manage.MarkAsCommitted();
            return domainEvents;
        }


    }
}