using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceEntities;

namespace Repositories
{
    public interface IFundRepository
    {
        Fund GetFundByName(string FundName);
    }
    public class FundRepository : IFundRepository
    {
        public Fund GetFundByName(string FundName)
        {
            return new Fund();
        }
    }
}
