using FinanceEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CharityFinanceTests
{
    [TestClass]
    public class PaymentTests
    {
        private Payment payment;

        [TestInitialize]
        public void Setup()
        {
            payment = new Payment
            {
                Date = DateTime.Parse("03/06/2018"),
                Description = "Council Tax",
                PaymentType = new PaymentType()
                {
                    Id = Guid.NewGuid(),
                    Description = "DDR",
                    LongDescription = "Direct Debit"
                },
                Amount = 210.00,
                BudgetType = new BudgetType()
                {
                    Id = Guid.NewGuid(),
                    Description = "CTAX",
                    LongDescription = "Council Tax"
                },
                SpendType = new SpendType()
                {
                    Id = Guid.NewGuid(),
                    Description = "Revenue",
                    LongDescription = "Revenue"
                }
            };
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

        [TestMethod]
        public void Payment_ValidateFields_False()
        {
            payment.SpendType = null;

            var actual = payment.FieldsValidated();

            Assert.IsFalse(actual);
        }
    }
}