﻿using FinanceDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FinanceServicesTest
{
    [TestClass]
    public class IncomeTests
    {
        private Income income;

        [TestInitialize]
        public void Setup()
        {
            income = Income.Create(
                 (TransactionDescription)"Offering 20/05/18",
                 DateTime.Parse("22/05/2018"),
                 new PaymentType()
                 {
                     Id = Guid.NewGuid(),
                     Description = "CSH",
                     LongDescription = "Cash"
                 },
                 230.00,
                 new BudgetType()
                 {
                     Id = Guid.NewGuid(),
                     Description = "GeneralIncome",
                     LongDescription = "General Income"
                 }, (Note)string.Empty);

            income.GiftAidStatus = GiftAidStatus.NotGiftAid;
        }

        [TestCleanup]
        public void CloseDown()
        {
            income = null;
        }

        [TestMethod]
        public void Income_AddIncome()
        {
            income.PayingInSlip = "000124";

            var expected = 230.00;

            var actual = income.Amount;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
    "A PayingIn Slip with non numeric characters is not allowed.")]
        public void Income_AddNANPayingSlip_ThrowException()
        {
            income.PayingInSlip = "P000124";

            Assert.Fail();
        }

        [TestMethod]
        public void Income_ValidateFields_True()
        {
            income.PayingInSlip = "000124";

            var actual = income.FieldsValidated();

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Income_ValidateFields_False()
        {
            var actual = income.FieldsValidated();

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Income_ValidatePayingInSlipIfCheque_True()
        {
            income.UpdatePaymentType(new PaymentType()
            {
                Id = Guid.NewGuid(),
                Description = "CHQ",
                LongDescription = "Cheque"
            });

            income.PayingInSlip = "000124";

            var actual = income.FieldsValidated();

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Income_ValidatePayingInSlipIfCheque_False()
        {
            income.UpdatePaymentType(new PaymentType()
            {
                Id = Guid.NewGuid(),
                Description = "CHQ",
                LongDescription = "Cheque"
            });

            var actual = income.FieldsValidated();

            Assert.IsFalse(actual);
        }
    }
}