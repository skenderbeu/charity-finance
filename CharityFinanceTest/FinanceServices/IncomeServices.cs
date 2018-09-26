using FinanceDomain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceServices
{
    public class IncomeServices : IIncomeServices
    {
        private IRepository<Income> incomeRepository;

        public IncomeServices()
        {
            this.incomeRepository = new IncomeRepository();
        }

        public IncomeServices(IncomeRepository incomeRepository)
        {
            this.incomeRepository = incomeRepository;
        }

        public IList<Income> GetIncomeByDescription(string description)
        {
            return incomeRepository.GetBy(i => i.Description == description);
        }

        public IList<Income> GetIncomeByDescription(string description, IList<Income> incomeToFilterBy)
        {
            return incomeToFilterBy.Where(i => i.Description == description).ToList();
        }

        public IList<Income> GetIncomeByDate(DateTime date)
        {
            return incomeRepository.GetBy(i => i.Date.Date == date.Date);
        }

        public IList<Income> GetIncomeByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            return incomeRepository.GetBy(i => i.Date.Date >= dateFrom && i.Date.Date <= dateTo);
        }

        public IList<Income> GetIncomeByBudgetType(BudgetType budgetType)
        {
            return incomeRepository.GetBy(i => i.BudgetType == budgetType);
        }

        public IList<Income> GetIncomeByBudgetType(BudgetType budgetType, IList<Income> incomeToFilterBy)
        {
            return incomeToFilterBy.Where(i => i.BudgetType == budgetType).ToList();
        }

        public IList<Income> GetIncomeByPaymentType(PaymentType paymentType)
        {
            return incomeRepository.GetBy(i => i.PaymentType == paymentType);
        }

        public IList<Income> GetIncomeByPaymentType(PaymentType paymentType, IList<Income> incomeToFilterBy)
        {
            return incomeToFilterBy.Where(i => i.PaymentType == paymentType).ToList();
        }

        public IList<Income> GetIncomeByAmount(double amount)
        {
            return incomeRepository.GetBy(i => i.Amount == amount);
        }

        public IList<Income> GetIncomeByAmount(double amount, IList<Income> incomeToFilterBy)
        {
            return incomeToFilterBy.Where(i => i.Amount == amount).ToList();
        }
    }
}