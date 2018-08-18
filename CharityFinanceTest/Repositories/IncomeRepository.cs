using FinanceEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private IEnumerable<Income> incomes;

        public IncomeRepository()
        {
        }

        //Used for Testing
        public IncomeRepository(IEnumerable<Income> incomes)
        {
            this.incomes = incomes;
        }

        public IEnumerable<Income> GetIncomeByDescription(string description)
        {
            return incomes.Where(i => i.Description == description);
        }

        public IEnumerable<Income> GetIncomeByDescription(string description, IEnumerable<Income> incomeToFilterBy)
        {
            return incomeToFilterBy.Where(i => i.Description == description);
        }

        public IEnumerable<Income> GetIncomeByDate(DateTime date)
        {
            return incomes.Where(i => i.Date.Date == date.Date);
        }

        public IEnumerable<Income> GetIncomeByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            return incomes.Where(i => i.Date.Date >= dateFrom && i.Date.Date <= dateTo);
        }

        public IEnumerable<Income> GetIncomeByBudgetType(BudgetTypes budgetType)
        {
            return incomes.Where(i => i.BudgetType == budgetType);
        }

        public IEnumerable<Income> GetIncomeByBudgetType(BudgetTypes budgetType, IEnumerable<Income> incomeToFilterBy)
        {
            return incomeToFilterBy.Where(i => i.BudgetType == budgetType);
        }

        public IEnumerable<Income> GetIncomeByPaymentType(PaymentTypes paymentType)
        {
            return incomes.Where(i => i.PaymentType == paymentType);
        }

        public IEnumerable<Income> GetIncomeByPaymentType(PaymentTypes paymentType, IEnumerable<Income> incomeToFilterBy)
        {
            return incomeToFilterBy.Where(i => i.PaymentType == paymentType);
        }

        public IEnumerable<Income> GetIncomeByAmount(double amount)
        {
            return incomes.Where(i => i.Amount == amount);
        }

        public IEnumerable<Income> GetIncomeByAmount(double amount, IEnumerable<Income> incomeToFilterBy)
        {
            return incomeToFilterBy.Where(i => i.Amount == amount);
        }

        public void Add(Income income)
        {
            //Add income to database
        }

        public void Update(Income income)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    incomes = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion IDisposable Support
    }
}