using FinanceEntities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repositories
{
    public interface ITransactionTypeRepository<T> where T : TransactionType
    {
        IList<T> GetAll();

        IList<T> GetBy(Expression<Func<T, bool>> expression);

        T GetById(int id);

        int Add(T transactionType);

        void Add(IList<T> transactionTypes);

        void Remove(T transactionType);

        void Remove(IList<T> transactionTypes);

        void Update(T transactionType);

        void Update(IList<T> transactionTypes);
    }
}