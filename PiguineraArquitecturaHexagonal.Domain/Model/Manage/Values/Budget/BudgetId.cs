

using PiguineraArquitecturaHexagonal.Domain.Generic;

namespace PiguineraArquitecturaHexagonal.Domain.Model.Manage.Values.Budget
{
    public class BudgetId : Identity
    {
        public BudgetId() : base() { }

        public BudgetId(string uuid) : base(uuid) { }

        public static BudgetId Of(string uuid)
        {
            return new BudgetId(uuid);
        }
    }
}
