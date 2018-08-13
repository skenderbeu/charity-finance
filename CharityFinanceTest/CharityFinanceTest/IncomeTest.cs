using FinanceEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CharityFinanceTests
{
    [TestClass]
    public class IncomeTests
    {
        [TestMethod]
        public void Income_AddIncome()
        {
            Income income = new Income
            {
                Date = DateTime.Parse("22/05/2018"),
                Description = "Offering 20/05/18",
                PaymentType = PaymentTypes.CASH,
                Amount = 230.00,
                BudgetType = BudgetTypes.GeneralIncome,
                PayingInSlip = "000124",
                GiftAidStatus = GiftAidStatus.NotGiftAid
            };

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
        [ExpectedException(typeof(ArgumentException),
    "A PayingIn Slip with non numeric characters is not allowed.")]
        public void Income_AddNANPayingSlip_ThrowException()
        {
            Income income = new Income
            {
                PayingInSlip = "P000124",
            };

            Assert.Fail();
        }

        [TestMethod]
        public void Income_ValidateFields_True()
        {
            Income income = new Income
            {
                Date = DateTime.Parse("22/05/2018"),
                Description = "Offering 20/05/18",
                PaymentType = PaymentTypes.CASH,
                PayingInSlip = "000124",
                Amount = 230.00,
                GiftAidStatus = GiftAidStatus.NotGiftAid,
                BudgetType = BudgetTypes.GeneralIncome
            };

            var actual = income.FieldsValidated();

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Income_ValidateFields_False()
        {
            Income income = new Income
            {
                Date = DateTime.Parse("22/05/2018"),
                Description = "Offering 20/05/18",
                PayingInSlip = "000124",
                Amount = 230.00,
                GiftAidStatus = GiftAidStatus.NotGiftAid,
                BudgetType = BudgetTypes.GeneralIncome
            };

            var actual = income.FieldsValidated();

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Income_ValidatePayingInSlipIfCash_True()
        {
            Income income = new Income
            {
                Date = DateTime.Parse("22/05/2018"),
                Description = "Offering 20/05/18",
                PaymentType = PaymentTypes.CASH,
                PayingInSlip = "000124",
                Amount = 230.00,
                GiftAidStatus = GiftAidStatus.NotGiftAid,
                BudgetType = BudgetTypes.GeneralIncome
            };

            var actual = income.FieldsValidated();

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Income_ValidatePayingInSlipIfCash_False()
        {
            Income income = new Income
            {
                Date = DateTime.Parse("22/05/2018"),
                Description = "Offering 20/05/18",
                PaymentType = PaymentTypes.CASH,
                Amount = 230.00,
                GiftAidStatus = GiftAidStatus.NotGiftAid,
                BudgetType = BudgetTypes.GeneralIncome
            };

            var actual = income.FieldsValidated();

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Income_ValidatePayingInSlipIfCheque_True()
        {
            Income income = new Income
            {
                Date = DateTime.Parse("22/05/2018"),
                Description = "Offering 20/05/18",
                PaymentType = PaymentTypes.CHQ,
                PayingInSlip = "000124",
                Amount = 230.00,
                GiftAidStatus = GiftAidStatus.NotGiftAid,
                BudgetType = BudgetTypes.GeneralIncome
            };

            var actual = income.FieldsValidated();

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Income_ValidatePayingInSlipIfCheque_False()
        {
            Income income = new Income
            {
                Date = DateTime.Parse("22/05/2018"),
                Description = "Offering 20/05/18",
                PaymentType = PaymentTypes.CHQ,
                Amount = 230.00,
                GiftAidStatus = GiftAidStatus.NotGiftAid,
                BudgetType = BudgetTypes.GeneralIncome
            };

            var actual = income.FieldsValidated();

            Assert.IsFalse(actual);
        }
    }
}