
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
        CouncilTax,
        MessyChurch,
        Building,
        Capital
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
        NotSet,
        BuildingFund,
        MessyChurch,
        Capital,
        Revenue,
        Children
    }

    public enum Month
    {
        NotSet,
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}
