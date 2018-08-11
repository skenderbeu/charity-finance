using FinanceEntities;
using System;
using System.Collections.Generic;

namespace CharityFinanceTests
{
    public class MockIncomes
    {
        public static List<Income> Incomes()
        {
            return new List<Income>()
            {
                new Income()
                {
                    Date = DateTime.Parse("01/05/2018"),
                    Description = "Offering 20/05/18",
                    PaymentType = PaymentTypes.CHQ,
                    PayingInSlip = "000124",
                    Amount = 100.00,
                    GiftAidStatus = GiftAidStatus.NotGiftAid,
                    BudgetType = BudgetTypes.Building,
                    FundType = FundTypes.BuildingFund,
                    BankCleared = true
                },
                new Income()
                {
                    Date = DateTime.Parse("22/05/2018"),
                    Description = "Offering 20/05/18",
                    PaymentType = PaymentTypes.CASH,
                    Amount = 100.00,
                    GiftAidStatus = GiftAidStatus.NotGiftAid,
                    BudgetType = BudgetTypes.Building,
                    FundType = FundTypes.BuildingFund,
                    BankCleared = true
                },
                new Income()
                {
                    Date = DateTime.Parse("01/05/2018"),
                    Description = "Messy Church donation",
                    PaymentType = PaymentTypes.CHQ,
                    PayingInSlip = "000124",
                    Amount = 200.00,
                    GiftAidStatus = GiftAidStatus.NotGiftAid,
                    BudgetType = BudgetTypes.MessyChurch,
                    FundType = FundTypes.MessyChurch
                },
                new Income()
                {
                    Date = DateTime.Parse("22/05/2018"),
                    Description = "Messy Church donation",
                    PaymentType = PaymentTypes.CASH,
                    Amount = 100.00,
                    GiftAidStatus = GiftAidStatus.NotGiftAid,
                    BudgetType = BudgetTypes.MessyChurch,
                    FundType = FundTypes.MessyChurch
                }
            };
        }
    }
}
