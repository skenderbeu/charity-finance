using FinanceEntities;

namespace Repositories
{
    public class PaymentTypeRepository : TransactionTypeRepository<PaymentType>
    {
        public PaymentTypeRepository() : base("dbo.PaymentType", "[dbo].[usp_paymentType_insert]")
        {
        }
    }
}