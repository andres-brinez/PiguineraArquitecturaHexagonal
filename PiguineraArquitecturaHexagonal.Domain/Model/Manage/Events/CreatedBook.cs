using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Events.Configuration;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Events
{
    public class CreatedBook: DomainEvent
    {
        public string IdSupplier;
        public string EmailSupplier;
        public int Seniority;
        public string Title;
        public int Quantity;
        public TypeBook BookType;
        public int OriginalPrice;
        public decimal Discount;
        public double UnitPrice;
        public double TotalPrice;




        public CreatedBook( 
                            string idSupplier,
                            string emailsupplier,
                            int seniority,
                            string title,
                            int quantity,
                            TypeBook bookType,
                            int originalPrice,
                            decimal discount,
                            double unitPrice,
                            double totalPrice
                            ) :
                            base(EventsEnumManage.BOOK_CREATED.ToString(),
                                $"{{\"idSupplier\":'\"{idSupplier}\"',"+
                                $"\"emailSupplier\":\"{emailsupplier}\"," +
                                $"\"seniority\":{seniority}," +
                                $"\"title\":\"{title}\"," +
                                $"\"quantity\":{quantity}," +
                                $"\"bookType\":\"{bookType}\"," +
                                $"\"originalPrice\":{originalPrice}," +
                                $"\"discount\":{discount}," +
                                $"\"unitPrice\":{unitPrice}," +
                                $"\"totalPrice\":{totalPrice}}}")
        {
            IdSupplier = idSupplier;
            EmailSupplier = emailsupplier;
            this.Seniority = seniority;
            Title = title;
            Quantity = quantity;
            BookType = bookType;
            OriginalPrice = originalPrice;
            Discount = discount;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }
    }
}
