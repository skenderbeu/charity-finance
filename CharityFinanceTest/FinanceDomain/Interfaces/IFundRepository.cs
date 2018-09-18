using System;

namespace FinanceDomain
{
    public interface IFundRepository : IDisposable
    {
        Fund GetFundByName(FundType fundType);

        Fund GetFundByNameAndDate(FundType fundType, DateTime date);
    }
}