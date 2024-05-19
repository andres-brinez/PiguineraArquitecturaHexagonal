using PiguineraArquitecturaHexagonal.Domain.Generic;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Book;
using PiguineraArquitecturaHexagonal.Domain.Model.Strategy;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Information;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Supplier;
using System.Text.Json.Serialization;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Entities
{
    public  class Book : Entity<BookId>,ICloneable
    {

        [JsonIgnore]
        public BookId Id { get; set; }
            
        private readonly List<IDiscountStrategy> _discountStrategies = new List<IDiscountStrategy>();

        public SupplierId IdSupplier;
        public Seniority Seniority;
        public Title Title;
        public Quantity Quantity;
        public BookType BookType;
        public OriginalPrice OriginalPrice;
        public Discount Discount;
        public UnitPrice UnitPrice;
        public Values.Book.TotalPrice _TotalPrice;


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
            CalculateUnitPrice();

            double totalPrice = System.Math.Round(UnitPrice.Value() * Quantity.Value(), 2);
            _TotalPrice = new Values.Book.TotalPrice(totalPrice);
        }


        public Book (string idProvider, decimal discount, string title, int quantity, TypeBook bookType, int unitPrice,string text) : base(new BookId())
        {
            IdSupplier = new SupplierId(idProvider);
            Discount = new Discount(discount);
            Title = new Title(title);
            Quantity = new Quantity(quantity);
            BookType = new BookType(bookType);
            UnitPrice = new UnitPrice(unitPrice);

            double totalPrice = System.Math.Round(UnitPrice.Value() * Quantity.Value(), 2);
            _TotalPrice = new Values.Book.TotalPrice(totalPrice);

        }


        public object Clone()
        {
            // Crear una nueva instancia de Book
            Book clone = new Book(this.Id);

            clone.IdSupplier = this.IdSupplier;
            clone.Seniority = this.Seniority;
            clone.Title = this.Title;
            clone.Quantity = this.Quantity;
            clone.BookType = this.BookType;
            clone.OriginalPrice = this.OriginalPrice;
            clone.Discount = this.Discount;
            clone.UnitPrice = this.UnitPrice;
            clone._TotalPrice = this._TotalPrice;

            return clone;
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
        public double GetTotalPrice()
        {
            return _TotalPrice.Value();
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

        public void CalculateUnitPrice()
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


        public void CalculaTotalPrice()
        {
            var newPrice = new Values.Book.TotalPrice((double)System.Math.Round(UnitPrice.Value() * Quantity.Value(), 2));
            _TotalPrice = newPrice;

        }
        public override string ToString()
        {
            return
                 $"{{\"IdSupplier\":{IdSupplier.Value()}," +
                 //$"{{\"IdSupplier\":\"{IdSupplier.Value()}\"," +
                 //$"\"Seniority\":\"{Seniority.Value()}\"," +
                 $"\"Title\":\"{Title.Value()}\"," +
                 $"\"Quantity\":{Quantity.Value()}," +
                 $"\"BookType\":\"{BookType.Value().ToString()}\"," +
                 //$"\"OriginalPrice\":{OriginalPrice}," +
                 $"\"Discount\":{Discount.Value()}," +
                 $"\"UnitPrice\":{UnitPrice.Value()}," +
                 $"\"TotalPrice\":{_TotalPrice.Value()}," +"}"; 
        }

       
    }
}
