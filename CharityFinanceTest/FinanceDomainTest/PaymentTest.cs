using FinanceDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FinanceServicesTest
{
    [TestClass]
    public class PaymentTests
    {
        private Payment payment;

        [TestInitialize]
        public void Setup()
        {
            payment = Payment.Create(
                (TransactionDescription)"Council Tax",
                DateTime.Parse("03/06/2018"),
                PaymentType.Create("DDR", "Direct Debit").Value,
                210.00,
                BudgetType.Create("CTAX","Council Tax"),
                SpendType.Create("Revenue","Revenue"),
                (Note)string.Empty, "",
                FundType.Create("Revenue", "Revenue"));
        }

        [TestMethod]
        public void Payment_AddPayment()
        {
            var expected = "Council Tax";

            var actual = payment.BudgetType.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Payment_ValidateFields_True()
        {
            var actual = payment.FieldsValidated();

            Assert.IsTrue(actual);
        }
    }
}