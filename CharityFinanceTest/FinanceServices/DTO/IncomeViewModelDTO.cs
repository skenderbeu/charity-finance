using FinanceDomain;
using Repositories;

namespace FinanceServices
{
    public class IncomeViewModelDTO
    {
        public IRepository<Income> IncomeRepository { get; set; }
        public ITransactionTypeRepository<PaymentType> PaymentTypeRepository { get; set; }
        public ITransactionTypeRepository<FundType> FundTypeRepository { get; set; }
        public ITransactionTypeRepository<SpendType> SpendTypeRepository { get; set; }
        public ITransactionTypeRepository<BudgetType> BudgetTypeRepository { get; set; }
    }
}