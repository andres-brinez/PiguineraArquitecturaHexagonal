using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Entities;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Events;
using System.Linq.Expressions;


namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Events.Configuration
{
    public class ManageEventChange : EventChange
    {
        public ManageEventChange(ManageAgregationRoot manage)
        {

            AddSub((DomainEvent @event) =>
            {
                if (@event is not CreatedBook) return;
                if (@event is not CreatedBook) return;
                var domainEvent = (CreatedBook)@event;

                manage.Book = new Book(domainEvent.IdSupplier,
                                        domainEvent.Seniority,
                                        domainEvent.Title,
                                        domainEvent.Quantity,
                                        domainEvent.BookType,
                                        domainEvent.OriginalPrice
                                       );


            });

            //AddSub((DomainEvent @event) =>
            //{
            //    if (@event is not CalculatedSeniority) return;
            //    var domainEvent = (CalculatedSeniority)@event;

            //    supplier.Information.CalculateSeniority(supplier.UserCredential.GetRegistrationDate());
            //    supplier.Information.CalculateSeniority(domainEvent.registerDate);

            //});

        }
    }
}