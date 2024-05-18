

using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;

namespace PiguineraArquitecturaHexagonal.Application.UseCases.Manage.Book
{
    public class CalculatePaymentUseCase : IInitialCommandUseCase<CalculatePaymentCommand>
    {
        private readonly IEventsRepository _repository;

        public CalculatePaymentUseCase(IEventsRepository repository)
        {
            _repository = repository;
        }

        // Puede retornar el libro
        public async Task<List<DomainEvent>> Execute(CalculatePaymentCommand command)
        {
            var manage = new ManageAgregationRoot(command.IdSupplier);
            manage.CalculatPayment(command.IdSupplier,command.BooksId, command.Books);

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