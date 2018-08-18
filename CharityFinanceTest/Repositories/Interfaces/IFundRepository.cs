using FinanceEntities;
using System;

namespace Repositories
{
    public interface IFundRepository : IDisposable
    {
        Fund GetFundByName(FundTypes fundType);

        Fund GetFundByNameAndDate(FundTypes fundType, DateTime date);
    }
}