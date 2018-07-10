using FinanceEntities;
using System;
using System.Collections.Generic;

namespace CharityFinanceTest
{
    public class MockPayments
    {
        
       public static List<Payment> Payments()
        {
            return new List<Payment>()
            {
               new Payment
                {
                    Date = DateTime.Parse("03/06/2018"),
                    Description = "Council Tax",
                    PaymentType = PaymentTypes.DDR,
                    Amount = 50.00,
                    BudgetType = BudgetTypes.Building,
                    SpendType = SpendTypes.Revenue,
                    FundType = FundTypes.BuildingFund
                },
                new Payment()
                {
                    Date = DateTime.Parse("23/06/2018"),
                    Description = "Council Tax",
                    PaymentType = PaymentTypes.DDR,
                    Amount = 50.00,
                    BudgetType = BudgetTypes.Building,
                    SpendType = SpendTypes.Revenue,
                    FundType = FundTypes.BuildingFund
                },
                new Payment
                {
                    Date = DateTime.Parse("03/06/2018"),
                    Description = "Messy Church payment",
                    PaymentType = PaymentTypes.DDR,
                    Amount = 50.00,
                    BudgetType = BudgetTypes.MessyChurch,
                    SpendType = SpendTypes.Revenue,
                    FundType = FundTypes.MessyChurch
                },
                new Payment()
                {
                    Date = DateTime.Parse("23/06/2018"),
                    Description = "Messy Church payment",
                    PaymentType = PaymentTypes.DDR,
                    Amount = 50.00,
                    BudgetType = BudgetTypes.MessyChurch,
                    SpendType = SpendTypes.Revenue,
                    FundType = FundTypes.MessyChurch
                }
            };
        }
    }
}
