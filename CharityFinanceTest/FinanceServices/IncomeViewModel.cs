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

        public IncomeViewModel(IRepository<Income> incomeRepository,
            ITransactionTypeRepository<PaymentType> paymentTypeRepository,
            ITransactionTypeRepository<BudgetType> budgetTypeRepository,
            ITransactionTypeRepository<FundType> fundTypeRepository,
            ITransactionTypeRepository<SpendType> spendTypeRepository)
        {
            this.incomeRepository = incomeRepository;
            this.paymentTypeRepository = paymentTypeRepository;
            this.budgetTypeRepository = budgetTypeRepository;
            this.fundTypeRepository = fundTypeRepository;
            this.spendTypeRepository = spendTypeRepository;
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