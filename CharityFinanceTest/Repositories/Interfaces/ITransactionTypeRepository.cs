using FinanceEntities;
using System.Collections.Generic;

namespace Repositories
{
    public interface ITransactionTypeRepository<T> where T : TransactionType
    {
        IList<T> GetAll();

        T GetById(int id);

        int AddTransactionType(T transactionType);

        void Remove(T transactionType);

        void Update(T transactionType);
    }
}