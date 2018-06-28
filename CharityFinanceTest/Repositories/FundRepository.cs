using System;
using System.Collections.Generic;
using System.Linq;
using FinanceEntities;

namespace Repositories
{
    public interface IFundRepository: IDisposable
    {
        Fund GetFundByName(FundTypes fundType);
        Fund GetFundByNameAndDate(FundTypes fundType, DateTime date);
    }

    public class FundRepository : IFundRepository
    {
        Fund fund;

        public FundRepository()
        {
            fund = new Fund();
        }

        public void Dispose()
        {
            fund = null;
        }

        public Fund GetFundByName(FundTypes fundType)
        {
            return fund;
        }

        public Fund GetFundByNameAndDate(FundTypes fundType, DateTime date)
        {
            return fund;
        }

        private IEnumerable<Income> GetIncomeByFundType(FundTypes fundType)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Payment> GetPaymentByFundType(FundTypes fundType)
        {
            throw new NotImplementedException();
        }
    }

    public class MockFundRepository : IFundRepository
    {
        Fund fund;

        public MockFundRepository()
        {
        }

        public Fund GetFundByName(FundTypes fundType)
        {
            var balance = GetIncomeByFundType(fundType).Sum(i => i.Amount) -
                        GetPaymentByFundType(fundType).Sum(p => p.Amount);

            fund = new Fund()
            {
                Balance = balance
            };

            return fund;
        }

        public Fund GetFundByNameAndDate(FundTypes fundType, DateTime date)
        {
            var balance = GetIncomeByFundType(fundType).Where(t => t.Date <= date).Sum(i => i.Amount) -
                GetPaymentByFundType(fundType).Where(t => t.Date <= date).Sum(p => p.Amount);

            fund = new Fund()
            {
                Balance = balance
            };

            return fund;
        }

        private IEnumerable<Income> GetIncomeByFundType(FundTypes fundType)
        {
            return CreateIncomeList().Where(t => t.FundType == fundType);
        }

        private IEnumerable<Payment> GetPaymentByFundType(FundTypes fundType)
        {
            return CreatePaymentList().Where(t => t.FundType == fundType);
        }

        private List<Income> CreateIncomeList()
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
                    FundType = FundTypes.BuildingFund
                },
                new Income()
                {
                    Date = DateTime.Parse("22/05/2018"),
                    Description = "Offering 20/05/18",
                    PaymentType = PaymentTypes.CASH,
                    Amount = 100.00,
                    GiftAidStatus = GiftAidStatus.NotGiftAid,
                    BudgetType = BudgetTypes.Building,
                    FundType = FundTypes.BuildingFund
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

        private List<Payment> CreatePaymentList()
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

        public void Dispose()
        {
            fund = null;
        }
    }
}
