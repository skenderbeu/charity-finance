using System.Collections.Generic;

namespace Repositories
{
    public interface IGetAllRepository<T> where T : class
    {
        IList<T> GetAll();
    }
}