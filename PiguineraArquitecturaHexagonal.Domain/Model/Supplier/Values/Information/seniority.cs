
using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Values.Information
{
    public class Seniority : IValueObject<int>
    {
        private readonly int Level;

        public Seniority(int level)
        {
            if (level<0)
            {
                throw new ArgumentException($"Invalid Seniority level: {level}");
            }

            Level = level;
        }

        public static Seniority Of(int level)
        {
            return new Seniority(level);
        }

        public int Value()
        {
            return Level;
        }

        public override string ToString()
        {
            return Level.ToString();
        }
    }

}