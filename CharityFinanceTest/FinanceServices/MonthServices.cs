using FinanceDomain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceServices
{
    public class MonthServices : IMonthServices
    {
        private IRepository<Income> incomeRepository;
        private IRepository<Payment> paymentRepository;

        public MonthServices(IRepository<Income> incomeRepository, IRepository<Payment> paymentRepository)
        {
            this.incomeRepository = incomeRepository;
            this.paymentRepository = paymentRepository;
        }

        public double GetPaymentsTotalByMonth(Month month, int year)
        {
            if (month == Month.NotSet) { throw new ArgumentException("Month has not been set properly"); }

            return paymentRepository.GetBy(p => p.Date.Month == (int)month && p.Date.Year == year)
                .Sum(p => p.Amount);
        }

        public double GetIncomeTotalByMonth(Month month, int year)
        {
            if (month == Month.NotSet) { throw new ArgumentException("Month has not been set properly"); }

            return incomeRepository.GetBy(i => i.Date.Month == (int)month && i.Date.Year == year)
                .Sum(i => i.Amount);
        }

        public double GetBankedClearedPaymentsTotalByMonth(Month month, int year)
        {
            return paymentRepository.GetBy(p => p.BankCleared == true && p.Date.Month == (int)month && p.Date.Year == year)
                .Sum(p => p.Amount);
        }

        public double GetBankedClearedIncomeTotalByMonth(Month month, int year)
        {
            return incomeRepository.GetBy(i => i.BankCleared == true && i.Date.Month == (int)month && i.Date.Year == year)
                .Sum(p => p.Amount);
        }

        public double GetOSChequesAmountByMonth(Month month, int year)
        {
            return paymentRepository.GetBy(p => p.PaymentType.Description == "CHQ"
                    && p.BankCleared == false
                    && p.Date.Month == (int)month
                    && p.Date.Year == year)
                .Sum(p => p.Amount);
        }

        public double GetOSPaidInAmountByMonth(Month month, int year)
        {
            return incomeRepository.GetBy(i => !string.IsNullOrWhiteSpace(i.PayingInSlip)
                    && i.Date.Month == (int)month
                    && i.Date.Year == year
                    && i.BankCleared == false)
                .Sum(i => i.Amount);
        }

        public IList<Payment> GetOSChequesByMonth(Month month, int year)
        {
            throw new NotImplementedException();
        }

        public IList<Income> GetOSPaidInByMonth(Month month, int year)
        {
            throw new NotImplementedException();
        }
    }
}