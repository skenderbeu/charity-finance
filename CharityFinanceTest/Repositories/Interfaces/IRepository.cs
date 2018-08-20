namespace Repositories
{
    public interface IRepository<T> : ISingleRepository<T>, IGetAllRepository<T>, IListRepository<T> where T : class
    {
    }
}