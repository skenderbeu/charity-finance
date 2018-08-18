using FinanceEntities;
using Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FinanceServices
{
    public class IncomeViewModel
    {
        private IIncomeRepository incomeRepository;
        private ITransactionTypeRepository<PaymentType> paymentTypeRepository;
        private ITransactionTypeRepository<BudgetType> budgetTypeRepository;
        private ITransactionTypeRepository<FundType> fundTypeRepository;
        private ITransactionTypeRepository<SpendType> spendTypeRepository;

        public IncomeViewModel()
        {
            this.incomeRepository = new IncomeRepository();
            this.paymentTypeRepository = new PaymentTypeRepository();
            this.budgetTypeRepository = new BudgetTypeRepository();
            this.fundTypeRepository = new FundTypeRepository();
            this.spendTypeRepository = new SpendTypeRepository();
        }

        public IncomeViewModel(IncomeViewModelDTO incomeViewModelDTO)
        {
            this.incomeRepository = incomeViewModelDTO.IncomeRepository;
            this.budgetTypeRepository = incomeViewModelDTO.BudgetTypeRepository;
            this.paymentTypeRepository = incomeViewModelDTO.PaymentTypeRepository;
            this.fundTypeRepository = incomeViewModelDTO.FundTypeRepository;
            this.spendTypeRepository = incomeViewModelDTO.SpendTypeRepository;
        }

        public IList<PaymentType> GetPaymentTypes()
        {
            return paymentTypeRepository.GetAll();
        }

        public IList<BudgetType> GetBudgetTypes()
        {
            return budgetTypeRepository.GetAll();
        }

        public IList<FundType> GetFundypes()
        {
            return fundTypeRepository.GetAll();
        }

        public IList<SpendType> GetSpendTypes()
        {
            return spendTypeRepository.GetAll();
        }

        public void Add(Income income)
        {
            if (income.FieldsValidated())
            {
                incomeRepository.Add(income);
            }
        }

        public void Update(Income income)
        {
            if (income.FieldsValidated())
            {
                incomeRepository.Update(income);
            }
        }

        public void Save()
        {
            incomeRepository.Save();
        }
    }
}