

using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands
{
    public class CalculateQuoteCommand : InitialCommand
    
    {
        public string IdSupplier;
        public List<List<Book>> GroupsBooks;

        public CalculateQuoteCommand(string idSupplier, List<List<Book>> groupsBooks)
        {
            IdSupplier = idSupplier;
            this.GroupsBooks = groupsBooks;
        }
    }
}
