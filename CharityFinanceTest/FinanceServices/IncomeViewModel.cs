using FinanceEntities;
using Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FinanceServices
{
    public class IncomeViewModel
    {
        private IIncomeRepository incomeRepository;
        private ITransactionTypeRepository paymentTypeRepository;
        private ITransactionTypeRepository budgetTypeRepository;
        private ITransactionTypeRepository fundTypeRepository;
        private ITransactionTypeRepository spendTypeRepository;

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

        public List<TransactionType> GetPaymentTypes()
        {
            return paymentTypeRepository.GetAll().ToList();
        }

        public List<TransactionType> GetBudgetTypes()
        {
            return budgetTypeRepository.GetAll().ToList();
        }

        public List<TransactionType> GetFundypes()
        {
            return fundTypeRepository.GetAll().ToList();
        }

        public List<TransactionType> GetSpendTypes()
        {
            return spendTypeRepository.GetAll().ToList();
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