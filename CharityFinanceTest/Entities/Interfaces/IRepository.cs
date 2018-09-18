namespace FinanceDomain
{
    public interface IRepository<T> : ISingleRepository<T>, IGetAllRepository<T>, IListRepository<T> where T : class
    {
    }
}