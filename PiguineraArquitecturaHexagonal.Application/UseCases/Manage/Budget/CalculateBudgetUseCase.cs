using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;
using System.Reactive.Linq;


namespace PiguineraArquitecturaHexagonal.Application.UseCases.Manage.Budget
{
    public class CalculateBudgetUseCase : IInitialCommandUseCase<CalculateBudgetCommand>
    {
        private readonly IEventsRepository _repository;

        public CalculateBudgetUseCase(IEventsRepository repository)
        {
            _repository = repository;
        }

        // Puede retornar el libro
        public async Task<List<DomainEvent>> Execute(CalculateBudgetCommand command)
        {
            var manage = new ManageAgregationRoot(command.IdSupplier);
            
            var budget = manage.Budget = new Domain.Model.Manage.Entities.Budget(command.Books,command.BudgetValue);

            manage.CalculateBudget(command.IdSupplier, budget.GetBooks(), budget.GetBudgetValue(),budget.GetBudgetValueFinal());

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