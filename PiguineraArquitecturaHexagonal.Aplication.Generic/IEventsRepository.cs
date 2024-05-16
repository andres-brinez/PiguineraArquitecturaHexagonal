﻿using PiguineraArquitecturaHexagonal.Domain.Generic;


namespace PiguineraArquitecturaHexagonal.Application.Generic
{ 
    // Se encarga de la persistencia de los eventos, es  lo unico que se guarda dentro del dominio
    // Puerto
    public interface IEventsRepository
    {
        Task<List<DomainEvent>> Save(DomainEvent domainEvent);
        Task<List<DomainEvent>> FindByAggregateId(string aggregateId);
    }
}