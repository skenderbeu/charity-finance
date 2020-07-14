using FinanceDomain;
using NHibernate;

namespace Repositories
{
    public class FundTypeRepository : TransactionTypeRepository<FundType>
    {
        public FundTypeRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}