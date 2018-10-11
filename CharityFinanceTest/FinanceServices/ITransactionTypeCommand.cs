using FinanceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceServices
{
    public interface ITransactionTypeCommand
    {
        Result Add(string description, string longDescription);

        void Delete(TransactionType transactionType);

        void Update(TransactionType transactionType);
    }
}