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
    }

    public interface IPaymentTypeCommand : ITransactionTypeCommand
    {
        void Delete(PaymentType paymentType);

        void Update(PaymentType paymentType);
    }
}