using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceDomain;
using Repositories;

namespace FinanceServices
{
    public class PaymentTypeCommand : ITransactionTypeCommand
    {
        private ITransactionTypeRepository<PaymentType> repository;

        public PaymentTypeCommand()
        {
            repository = new PaymentTypeRepository();
        }

        public Result Add(string description, string longDescription)
        {
            throw new NotImplementedException();
        }

        public void Delete(TransactionType transactionType)
        {
            repository.Remove(transactionType as PaymentType);
        }

        public void Update(TransactionType transactionType)
        {
            repository.Update(transactionType as PaymentType);
        }
    }
}