using System.Collections.Generic;

namespace Repositories
{
    public interface ITransactionTypeRepository<T> where T : struct
    {
        IList<T> GetTypes();

        void AddTransactionType(string description, string longDescription);
    }
}