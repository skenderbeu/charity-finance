﻿namespace Repositories
{
    public interface ITransactionTypeRepository<T> : ISingleRepository<T>, IGetAllRepository<T> where T : class
    { }
}