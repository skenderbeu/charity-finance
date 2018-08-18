using Repositories;

namespace FinanceServices
{
    public class IncomeViewModelDTO
    {
        public IIncomeRepository IncomeRepository { get; set; }
        public ITransactionTypeRepository PaymentTypeRepository { get; set; }
        public ITransactionTypeRepository FundTypeRepository { get; set; }
        public ITransactionTypeRepository SpendTypeRepository { get; set; }
        public ITransactionTypeRepository BudgetTypeRepository { get; set; }
    }
}