using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;
using PiguineraArquitecturaHexagonal.Domain.Model.Strategy;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Information;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Supplier;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities
{
    public  class Book : Entity<BookId>
    {
        private readonly List<IDiscountStrategy> _discountStrategies = new List<IDiscountStrategy>();

        private SupplierId IdSupplier;
        private Seniority Seniority;
        private Title Title;
        private Quantity Quantity;
        private BookType BookType;
        private OriginalPrice OriginalPrice;
        private Discount Discount;
        private UnitPrice UnitPrice;

        public Book(BookId id) : base(id)
        {
        }

        public Book(string idProvider,int seniority, string title, int quantity, TypeBook bookType, int originalPrice) : base (new BookId())
        {
            IdSupplier =new SupplierId(idProvider);
            Seniority = new Seniority(seniority);
            Title =new Title(title);
            Quantity =new Quantity(quantity);
            BookType =new BookType(bookType);
            OriginalPrice =new OriginalPrice(originalPrice);

            _discountStrategies = new List<IDiscountStrategy>
            {
                new SeniorityOneTwoDiscountStrategy(),
                new SeniorityMoreThanTwoDiscountStrategy()
            };

            CalculateDiscountSeniority();
            CalculateTotalPrice();
        }

      
        public int GetSeniority()
        {
            return Seniority.Value();
        }

        public string GetTitle()
        {
            return Title.Value();
        }

        public int GetQuantity() 
        {
            return Quantity.Value();
        }

        public TypeBook GetBookType()
        {
            return BookType.Value();
        }

        public int GetOriginalPrice() 
        {
            return OriginalPrice.Value(); 
        }

        public decimal GetDiscount()
        {
            return Discount?.Value() ?? 0m;
        }


        public double GetUnitPrice() 
        {
            return UnitPrice.Value(); 
        }

        public void CalculateDiscountSeniority()
        {

            foreach (var strategy in _discountStrategies)
            {

                if (strategy.CanApply(Seniority.Value()))
                {
                    Console.WriteLine(strategy.Apply());

                    this.Discount = new Discount(strategy.Apply());
                    break;
                }
                
            }
        }

        public void CalculateTotalPrice()
        {

            if (BookType.Value()== TypeBook.BOOK)
            {
                Console.WriteLine("Es de tipo libro");
                const Double CURRENT_INCREASE = 0.33;

                CalculateDiscountSeniority();

                decimal totalPrice = (decimal)(OriginalPrice.Value() + (OriginalPrice.Value() * CURRENT_INCREASE));

                double currentPrice = (double)(totalPrice * (1 - (Discount?.Value() ?? 0)));

                this.UnitPrice = new UnitPrice(currentPrice);
            }
            else if (BookType.Value() == TypeBook.NOVEL)
            {
                Console.WriteLine("Es de tipo Novela");

                const decimal CURRENT_INCREASE = 2;

                CalculateDiscountSeniority();

                double currentPrice = (double)(OriginalPrice.Value() * CURRENT_INCREASE * (1 - (Discount?.Value() ?? 0)));

                this.UnitPrice = new UnitPrice(currentPrice);
            }
        }



    }
}
