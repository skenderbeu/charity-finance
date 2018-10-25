using FinanceDomain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace FinanceServices
{
    public class IncomeViewModel : IIncomeViewModel
    {
        private IRepository<Income> incomeRepository;
        private ITransactionTypeRepository<PaymentType> paymentTypeRepository;
        private ITransactionTypeRepository<BudgetType> budgetTypeRepository;
        private ITransactionTypeRepository<FundType> fundTypeRepository;
        private ITransactionTypeRepository<SpendType> spendTypeRepository;

        public IncomeViewModel()
        {
            incomeRepository = new IncomeRepository();
            paymentTypeRepository = new PaymentTypeRepository();
            budgetTypeRepository = new BudgetTypeRepository();
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

        public IList<FundType> GetFundTypes()
        {
            return fundTypeRepository.GetAll();
        }

        public IList<SpendType> GetSpendTypes()
        {
            return spendTypeRepository.GetAll();
        }
    }
}