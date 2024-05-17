

namespace PiguineraArquitecturaHexagonal.Domain.Model.Strategy
{
    public interface IDiscountStrategy
    {

        bool CanApply(int seniority);
        decimal Apply();

    }
}
