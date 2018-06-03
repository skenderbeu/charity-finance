using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceEntities
{
    public enum PaymentTypes
    {
        CHQ,
        BAC,
        SO,
        CASH,
        DDR
    }

    public enum BudgetTypes
    {
        GeneralIncome,
        CouncilTax
    }

    public enum GiftAidStatus
    {
        NotGiftAid,
        GiftAid
    }

    public enum SpendTypes
    {
        Capital,
        Revenue
    }
}
