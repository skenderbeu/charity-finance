using FinanceEntities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceServices
{
    public class PaymentServices : IPaymentServices
    {
        private IRepository<Payment> paymentRepository;

        public PaymentServices(IRepository<Payment> paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        public IList<Payment> GetPaymentsByAmount(double amount)
        {
            return paymentRepository.GetBy(p => p.Amount == amount);
        }

        public IList<Payment> GetPaymentsByAmount(double amount, IList<Payment> paymentsToFilterBy)
        {
            return paymentsToFilterBy.Where(p => p.Amount == amount).ToList();
        }

        public IList<Payment> GetPaymentsByBudgetType(BudgetType budgetType)
        {
            return paymentRepository.GetBy(p => p.BudgetType == budgetType);
        }

        public IList<Payment> GetPaymentsByBudgetType(BudgetType budgetType, IList<Payment> paymentsToFilterBy)
        {
            return paymentsToFilterBy.Where(p => p.BudgetType == budgetType).ToList();
        }

        public IList<Payment> GetPaymentsByDate(DateTime date)
        {
            return paymentRepository.GetBy(p => p.Date.Date == date.Date);
        }

        public IList<Payment> GetPaymentsByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            return paymentRepository.GetBy(p => p.Date.Date >= dateFrom && p.Date.Date <= dateTo);
        }

        public IList<Payment> GetPaymentsByDescription(string description)
        {
            return paymentRepository.GetBy(p => TrimUpperReplaceBlank(p.Description).Contains(TrimUpperReplaceBlank(description)));
        }

        public IList<Payment> GetPaymentsByDescription(string description, IList<Payment> paymentsToFilterBy)
        {
            return paymentsToFilterBy.Where(p => TrimUpperReplaceBlank(p.Description).Contains(TrimUpperReplaceBlank(description))).ToList();
        }

        public IList<Payment> GetPaymentsByPaymentType(PaymentType paymentType)
        {
            return paymentRepository.GetBy(p => p.PaymentType == paymentType);
        }

        public IList<Payment> GetPaymentsByPaymentType(PaymentType paymentType, IList<Payment> paymentsToFilterBy)
        {
            return paymentsToFilterBy.Where(p => p.PaymentType == paymentType).ToList();
        }

        private string TrimUpperReplaceBlank(string input)
        {
            return input.ToUpper().Trim().Replace(" ", "");
        }
    }
}