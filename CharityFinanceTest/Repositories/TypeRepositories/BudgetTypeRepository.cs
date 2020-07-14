using FinanceDomain;
using NHibernate;

namespace Repositories
{
    public class BudgetTypeRepository : TransactionTypeRepository<BudgetType>
    {
        public BudgetTypeRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}