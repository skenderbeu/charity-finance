using System;
using System.Collections.Generic;
using System.Linq;
using FinanceEntities;

namespace Repositories
{
    public interface IFundRepository: IDisposable
    {
        Fund GetFundByName(FundTypes fundType);
        Fund GetFundByNameAndDate(FundTypes fundType, DateTime date);
    }

    public class FundRepository : IFundRepository
    {
        Fund fund;
        List<Income> incomes;
        List<Payment> payments;

        public FundRepository()
        {
        }

        //Used for Testing
        public FundRepository(List<Income> incomes, List<Payment> payments)
        {
            this.incomes = incomes;
            this.payments = payments;
        }

        public void Dispose()
        {
            fund = null;
        }

        public Fund GetFundByName(FundTypes fundType)
        {
            var balance = GetIncomeByFundType(fundType).Sum(i => i.Amount) -
                         GetPaymentByFundType(fundType).Sum(p => p.Amount);

            fund = new Fund()
            {
                Balance = balance
            };

            return fund;
        }

        public Fund GetFundByNameAndDate(FundTypes fundType, DateTime date)
        {
            var balance = GetIncomeByFundType(fundType).Where(t => t.Date <= date).Sum(i => i.Amount) -
                GetPaymentByFundType(fundType).Where(t => t.Date <= date).Sum(p => p.Amount);

            fund = new Fund()
            {
                Balance = balance
            };

            return fund;
        }

        private IEnumerable<Income> GetIncomeByFundType(FundTypes fundType)
        {
            return incomes.Where(t => t.FundType == fundType);
        }

        private IEnumerable<Payment> GetPaymentByFundType(FundTypes fundType)
        {
            return payments.Where(t => t.FundType == fundType);
        }
    }
}
