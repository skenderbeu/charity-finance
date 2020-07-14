using FinanceDomain;
using NHibernate;

namespace Repositories
{
    public class PaymentRepository : RepositoryBase<Payment>
    {
        public PaymentRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}