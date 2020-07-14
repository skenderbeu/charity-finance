using FinanceDomain;
using NHibernate;

namespace Repositories
{
    public class SpendTypeRepository : TransactionTypeRepository<SpendType>
    {
        public SpendTypeRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}