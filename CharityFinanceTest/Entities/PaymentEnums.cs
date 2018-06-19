using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceEntities
{
    public enum PaymentTypes
    {
        NotSet,
        CHQ,
        BAC,
        SO,
        CASH,
        DDR
    }

    public enum BudgetTypes
    {
        NotSet,
        GeneralIncome,
        CouncilTax
    }

    public enum GiftAidStatus
    {
        NotSet,
        NotGiftAid,
        GiftAid
    }

    public enum SpendTypes
    {
        NotSet,
        Capital,
        Revenue
    }

    public enum FundTypes
    {
        BuildingFund,
        MessyChurch,
        Capital
    }
}
