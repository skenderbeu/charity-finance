using FinanceEntities;
using System.Collections.Generic;

namespace Repositories
{
    public interface ITransactionTypeRepository<T> where T : struct
    {
        IList<T> GetAll();

        void AddTransactionType(TransactionType transactionType);

        TransactionType FindById(int id);

        void Remove(TransactionType transactionType);
    }
}