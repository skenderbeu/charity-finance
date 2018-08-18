using FinanceEntities;

namespace Repositories
{
    public class BudgetTypeRepository : TransactionTypeRepository<BudgetType>
    {
        public BudgetTypeRepository() : base("dbo.BudgetType", "[dbo].[usp_budgetType_insert]")
        {
        }
    }
}