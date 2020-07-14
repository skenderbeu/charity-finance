using FinanceDomain;

namespace FinanceServices
{
    public class PaymentTypeCommands : IPaymentTypeCommand
    {
        private readonly ITransactionTypeRepository<PaymentType> repository;

        public PaymentTypeCommands(ITransactionTypeRepository<PaymentType> repository)
        {
            this.repository = repository;
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