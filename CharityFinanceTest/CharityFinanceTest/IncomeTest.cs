using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinanceEntities;

namespace CharityFinanceTests
{
    [TestClass]
    public class IncomeTests
    {
        [TestMethod]
        public void Income_AddIncome()
        {
            Income income = new Income{
                Date = DateTime.Parse("22/05/2018"),
                Description = "Offering 20/05/18",
                PaymentType = PaymentTypes.CASH,
                PayingInSlip = "000124",
                Amount = 230.00,
                GiftAidStatus = GiftAidStatus.NotGiftAid,
                BudgetType = BudgetTypes.GeneralIncome };


            var expected = 230.00;
                
            var actual = income.Amount;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Income_AddPayingSlip_Accepted()
        {
            Income income = new Income
            {
                PayingInSlip = "000124",
            };

            var expected = "000124";

            var actual = income.PayingInSlip;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Income_AddNANPayingSlip_Rejected()
        {
            Income income = new Income
            {
                PayingInSlip = "P000124",
            };

            var actual = income.PayingInSlip;

            Assert.AreEqual(null, actual);
        }
    }
}
