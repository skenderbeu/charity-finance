using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceDomain;
using Repositories;

namespace FinanceServices
{
    public class PaymentTypeCommands : IPaymentTypeCommand
    {
        private ITransactionTypeRepository<PaymentType> repository;

        public PaymentTypeCommands()
        {
            repository = new PaymentTypeRepository();
        }

        public Result Add(string description, string longDescription)
        {
            var result = PaymentType.Create(description, longDescription);

            if (result.IsSuccess)
            {
                repository.Add(result.Value);
            }

            return result;
        }

        public void Delete(PaymentType paymentType)
        {
            repository.Remove(paymentType);
        }

        public void Update(PaymentType paymentType)
        {
            repository.Update(paymentType);
        }
    }
}