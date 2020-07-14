using FinanceDomain;
using NHibernate;

namespace Repositories
{
    public class IncomeRepository : RepositoryBase<Income>
    {
        public IncomeRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}