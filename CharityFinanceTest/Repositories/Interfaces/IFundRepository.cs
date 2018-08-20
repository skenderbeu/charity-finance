using FinanceEntities;
using System;

namespace Repositories
{
    public interface IFundRepository : IDisposable
    {
        Fund GetFundByName(FundType fundType);

        Fund GetFundByNameAndDate(FundType fundType, DateTime date);
    }
}