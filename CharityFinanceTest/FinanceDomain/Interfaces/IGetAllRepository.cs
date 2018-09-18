using System.Collections.Generic;

namespace FinanceDomain
{
    public interface IGetAllRepository<T> where T : class
    {
        IList<T> GetAll();
    }
}