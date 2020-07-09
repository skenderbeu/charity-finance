using FinanceDomain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceServices
{
    public class PaymentTypeViewModel : IPaymentTypeViewModel
    {
        private ITransactionTypeRepository<PaymentType> paymentTypeRepository;

        public PaymentTypeViewModel()
        {
            paymentTypeRepository = new PaymentTypeRepository();
        }

        public IList<PaymentType> GetPaymentTypes()
        {
            return paymentTypeRepository.GetAll();
        }
    }
}
