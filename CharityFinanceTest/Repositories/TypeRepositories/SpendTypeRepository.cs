using FinanceEntities;

namespace Repositories
{
    public class SpendTypeRepository : TransactionTypeRepository<SpendType>
    {
        public SpendTypeRepository() : base("dbo.SpendType", "[dbo].[usp_spendType_insert]")
        {
        }
    }
}