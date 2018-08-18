using FinanceEntities;

namespace Repositories
{
    public class FundTypeRepository : TransactionTypeRepository<FundType>
    {
        public FundTypeRepository() : base("dbo.FundType", "[dbo].[usp_fundType_insert]")
        {
        }
    }
}