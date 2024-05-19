using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;


namespace PiguineraArquitecturaHexagonal.Application.UseCases.Manage.Quote
{
    public class GenerateQuoteUseCase : IInitialCommandUseCase<CalculateQuoteCommand>
    {
        private readonly IEventsRepository _repository;

        public GenerateQuoteUseCase(IEventsRepository repository)
        {
            _repository = repository;
        }

        // Puede retornar el libro
        public async Task<List<DomainEvent>> Execute(CalculateQuoteCommand command)
        {
            var manage = new ManageAgregationRoot(command.IdSupplier);

            var quote = manage.Quote = new Domain.Model.Manage.Entities.Quote(command.GroupsBooks);
            Console.WriteLine("Casos de uso");
            Console.WriteLine(quote.GetTotalPrice());

            manage.CalculateQuote(command.IdSupplier, quote.GetQuotes(), command.GroupsBooks, quote.GetTotalPrice());

            var domainEvents = manage.GetUncommittedChanges().ToList();

            domainEvents.ForEach(async (domainEvent) =>
            {
                //await _repository.Save(domainEvent);
            });

            manage.MarkAsCommitted();
            return domainEvents;
        }


    }
}