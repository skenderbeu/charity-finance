﻿using FinanceEntities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceServices
{
    public class EditIncomeViewModel : IEditIncomeViewModel
    {
        private IRepository<Income> incomeRepository;
        private ITransactionTypeRepository<PaymentType> paymentTypeRepository;
        private ITransactionTypeRepository<BudgetType> budgetTypeRepository;
        private ITransactionTypeRepository<FundType> fundTypeRepository;
        private ITransactionTypeRepository<SpendType> spendTypeRepository;

        public EditIncomeViewModel()
        {
            this.incomeRepository = new IncomeRepository<Income>();
            this.paymentTypeRepository = new PaymentTypeRepository();
            this.budgetTypeRepository = new BudgetTypeRepository();
            this.fundTypeRepository = new FundTypeRepository();
            this.spendTypeRepository = new SpendTypeRepository();
        }

        public EditIncomeViewModel(IncomeViewModelDTO incomeViewModelDTO)
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

        public void Delete(Income income)
        {
            incomeRepository.Remove(income);
        }
    }
}