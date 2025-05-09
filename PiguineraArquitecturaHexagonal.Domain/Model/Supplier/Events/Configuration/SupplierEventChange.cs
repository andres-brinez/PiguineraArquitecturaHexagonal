﻿using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Entities;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Events
{
    public class SupplierEventChange : EventChange
    {
        public SupplierEventChange(SupplierAgregateRoot supplier)
        {

            AddSub((DomainEvent @event) =>
            {
                if (@event is not CreatedSupplier) return;
                if (@event is not CreatedSupplier) return;
                var domainEvent = (CreatedSupplier)@event;

                supplier.UserCredential = new UserCredential(domainEvent.Email, domainEvent.Password);
                supplier.Information = new Information("Andres", "", "2323");
                supplier.Information.CalculateSeniority(supplier.Information.GetRegistrationDate());


            });

            AddSub((DomainEvent @event) =>
            {
                if (@event is not CalculatedSeniority) return;
                var domainEvent = (CalculatedSeniority)@event;

                //supplier.Information.CalculateSeniority(supplier.UserCredential.GetRegistrationDate());
                supplier.Information.CalculateSeniority(domainEvent.registerDate);

            });

        }
    }
}