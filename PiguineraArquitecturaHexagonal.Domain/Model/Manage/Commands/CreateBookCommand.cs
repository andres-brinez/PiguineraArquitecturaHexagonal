﻿


using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands
{
    public class CreateBookCommand : InitialCommand
    {
        public string idSupplier;
        public int seniority;
        public string title;
        public int quantity;
        public TypeBook bookType;
        public int originalPrice;

        public CreateBookCommand(   string idProvider, 
                                    int seniority,
                                    string title,
                                    int quantity,
                                    TypeBook bookType,
                                    int originalPrice
            )
        {
            this.idSupplier = idProvider;
            this.seniority = seniority;
            this.title = title;
            this.quantity = quantity;
            this.bookType = bookType;
            this.originalPrice = originalPrice;
        }
    }
}
