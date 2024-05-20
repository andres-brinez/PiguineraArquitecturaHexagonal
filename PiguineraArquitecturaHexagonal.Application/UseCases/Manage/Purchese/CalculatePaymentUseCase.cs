using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;
using System.Reactive.Linq;

namespace PiguineraArquitecturaHexagonal.Application.UseCases.Manage.Purchese
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
            var purchese = manage.Purchese = new Domain.Model.Manage.Entities.Purchese(command.Books);

            manage.CalculatePayment(command.IdSupplier, command.BooksId, purchese.GetBooks(),purchese.GetTotalPrice(),purchese.GetTypePurchase(),purchese.GetQuantityBook());

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