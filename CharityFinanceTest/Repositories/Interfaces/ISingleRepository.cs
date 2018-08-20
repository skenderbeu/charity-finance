using System;

namespace Repositories
{
    public interface ISingleRepository<T> where T : class
    {
        T GetById(Guid id);

        Guid Add(T entity);

        void Remove(T entity);

        void Update(T entity);
    }
}