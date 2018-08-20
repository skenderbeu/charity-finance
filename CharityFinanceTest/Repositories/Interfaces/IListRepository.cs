using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repositories
{
    public interface IListRepository<T> where T : class
    {
        IList<T> GetBy(Expression<Func<T, bool>> expression);

        List<Guid> Add(IList<T> entities);

        void Remove(IList<T> entities);

        void Update(IList<T> entities);
    }
}