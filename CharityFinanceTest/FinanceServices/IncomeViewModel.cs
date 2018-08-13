using FinanceEntities;
using Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FinanceServices
{
    public class IncomeViewModel
    {
        private IIncomeRepository incomeRepository;
        private PaymentTypeRepository paymentTypeRepository;

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

        public List<PaymentType> GetPaymentTypes()
        {
            return paymentTypeRepository.GetPaymentTypes().ToList();
        }

        public void AddIncome(Income income)
        {
            incomeRepository.AddIncome(income);
        }
    }
}