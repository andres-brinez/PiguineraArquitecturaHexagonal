

namespace PandemyLagacyDDD.Domain.Generic
{
    public abstract class Command<T> where T : Identity
    {
        // Los comandos son los que llegan a los casos de uso
        // Se  puede ver como un DTO
        // En el comando se envia toda la información de alguna acción que se quiera realizar 

        // Este comando es para agregados que ya existen
        public T AggregateId { get; set; }

        protected Command(T aggregateId)
        {
            AggregateId = aggregateId;
        }
    }

    //  Cuando se  crea  un nuevo agregado se utiliza este comando porque no se tiene el id del aggregate
    public abstract class InitialCommand
    {
    }
}