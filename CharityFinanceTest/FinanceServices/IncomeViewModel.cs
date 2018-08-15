using FinanceEntities;
using Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FinanceServices
{
    public class IncomeViewModel
    {
        private IIncomeRepository incomeRepository;
        private ITransactionTypeRepository<TransactionType> paymentTypeRepository;

        public IncomeViewModel()
        {
            this.incomeRepository = new IncomeRepository();
            this.paymentTypeRepository = new PaymentTypeRepository();
        }

        public IncomeViewModel(IIncomeRepository incomeRepository)
        {
            this.incomeRepository = incomeRepository;
            this.paymentTypeRepository = new PaymentTypeRepository();
        }

        public List<TransactionType> GetPaymentTypes()
        {
            return paymentTypeRepository.GetAll().ToList();
        }

        public void AddIncome(Income income)
        {
            incomeRepository.AddIncome(income);
        }
    }
}