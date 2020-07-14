using FinanceDomain;
using NHibernate;

namespace Repositories
{
    public class PaymentTypeRepository : TransactionTypeRepository<PaymentType>
    {
        public PaymentTypeRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}