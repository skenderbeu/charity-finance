using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }

    public class MockFundRepository : IFundRepository
    {
        Fund fund;

        public MockFundRepository()
        {
        }

        public Fund GetFundByName(FundTypes fundType)
        {
            var balance = CreateIncomeList().Where(t => t.FundType == fundType).Sum(i => i.Amount) -
                CreatePaymentList().Where(t => t.FundType == fundType).Sum(p => p.Amount);

            fund = new Fund()
            {
                Balance = balance
            };

            return fund;
        }

        public Fund GetFundByNameAndDate(FundTypes fundType, DateTime date)
        {
            var balance = CreateIncomeList().Where(t => t.FundType == fundType && t.Date <= date).Sum(i => i.Amount) -
                CreatePaymentList().Where(t => t.FundType == fundType && t.Date <= date).Sum(p => p.Amount);

            fund = new Fund()
            {
                Balance = balance
            };

            return fund;
        }

        private IQueryable GetIncomeByFundType(FundTypes fundType)
        {
            return CreateIncomeList().Where(t => t.FundType == fundType);
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
                    BudgetType = BudgetTypes.GeneralIncome,
                    FundType = FundTypes.BuildingFund
                },
                new Income()
                {
                    Date = DateTime.Parse("22/05/2018"),
                    Description = "Offering 20/05/18",
                    PaymentType = PaymentTypes.CASH,
                    Amount = 100.00,
                    GiftAidStatus = GiftAidStatus.NotGiftAid,
                    BudgetType = BudgetTypes.GeneralIncome,
                    FundType = FundTypes.BuildingFund
                },
                new Income()
                {
                    Date = DateTime.Parse("01/05/2018"),
                    Description = "Offering 20/05/18",
                    PaymentType = PaymentTypes.CHQ,
                    PayingInSlip = "000124",
                    Amount = 200.00,
                    GiftAidStatus = GiftAidStatus.NotGiftAid,
                    BudgetType = BudgetTypes.GeneralIncome,
                    FundType = FundTypes.MessyChurch
                },
                new Income()
                {
                    Date = DateTime.Parse("22/05/2018"),
                    Description = "Offering 20/05/18",
                    PaymentType = PaymentTypes.CASH,
                    Amount = 100.00,
                    GiftAidStatus = GiftAidStatus.NotGiftAid,
                    BudgetType = BudgetTypes.GeneralIncome,
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
                    BudgetType = BudgetTypes.CouncilTax,
                    SpendType = SpendTypes.Revenue,
                    FundType = FundTypes.BuildingFund
                },
                new Payment()
                {
                    Date = DateTime.Parse("23/06/2018"),
                    Description = "Council Tax",
                    PaymentType = PaymentTypes.DDR,
                    Amount = 50.00,
                    BudgetType = BudgetTypes.CouncilTax,
                    SpendType = SpendTypes.Revenue,
                    FundType = FundTypes.BuildingFund
                },
                new Payment
                {
                    Date = DateTime.Parse("03/06/2018"),
                    Description = "Council Tax",
                    PaymentType = PaymentTypes.DDR,
                    Amount = 50.00,
                    BudgetType = BudgetTypes.GeneralIncome,
                    SpendType = SpendTypes.Revenue,
                    FundType = FundTypes.MessyChurch
                },
                new Payment()
                {
                    Date = DateTime.Parse("23/06/2018"),
                    Description = "Council Tax",
                    PaymentType = PaymentTypes.DDR,
                    Amount = 50.00,
                    BudgetType = BudgetTypes.GeneralIncome,
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
