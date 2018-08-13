using FinanceEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CharityFinanceTests
{
    [TestClass]
    public class PaymentTests
    {
        [TestMethod]
        public void Payment_AddPayment()
        {
            Payment payment = new Payment
            {
                Date = DateTime.Parse("03/06/2018"),
                Description = "Council Tax",
                PaymentType = PaymentTypes.DDR,
                Amount = 210.00,
                BudgetType = BudgetTypes.CouncilTax,
                SpendType = SpendTypes.Revenue
            };

            var expected = "CouncilTax";

            var actual = payment.BudgetType.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Payment_ValidateFields_True()
        {
            Payment payment = new Payment
            {
                Date = DateTime.Parse("03/06/2018"),
                Description = "Council Tax",
                PaymentType = PaymentTypes.DDR,
                Amount = 210.00,
                BudgetType = BudgetTypes.CouncilTax,
                SpendType = SpendTypes.Revenue
            };

            var actual = payment.FieldsValidated();

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Payment_ValidateFields_False()
        {
            Payment payment = new Payment
            {
                Date = DateTime.Parse("03/06/2018"),
                Description = "Council Tax",
                PaymentType = PaymentTypes.DDR,
                Amount = 210.00,
                BudgetType = BudgetTypes.CouncilTax
            };

            var actual = payment.FieldsValidated();

            Assert.IsFalse(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Payment_ValidateFundType_ThrowsException()
        {
            Payment payment = new Payment
            {
                Date = DateTime.Parse("03/06/2018"),
                Description = "Council Tax",
                PaymentType = PaymentTypes.DDR,
                Amount = 210.00,
                BudgetType = BudgetTypes.NotSet,
                FundType = FundTypes.MessyChurch
            };

            payment.GetFund();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Payment_ValidateFundTypeNoBudgetType_ThrowsException()
        {
            Payment payment = new Payment
            {
                Date = DateTime.Parse("03/06/2018"),
                Description = "Council Tax",
                PaymentType = PaymentTypes.DDR,
                Amount = 210.00,
                FundType = FundTypes.MessyChurch
            };

            payment.GetFund();
        }

        [TestMethod]
        public void Payment_ValidateFundType_NoException()
        {
            Payment payment = new Payment
            {
                Date = DateTime.Parse("03/06/2018"),
                Description = "Council Tax",
                PaymentType = PaymentTypes.DDR,
                Amount = 210.00,
                BudgetType = BudgetTypes.MessyChurch,
                FundType = FundTypes.MessyChurch
            };
        }
    }
}