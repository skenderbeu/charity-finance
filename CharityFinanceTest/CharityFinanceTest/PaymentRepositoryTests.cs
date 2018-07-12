using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CharityFinanceTest
{
    [TestClass]
    public class PaymentRepositoryTests
    {
        IPaymentRepository repo;

        [TestInitialize]
        public void Setup()
        {
            repo = new PaymentRepository(MockPayments.Payments());
        }

        [TestCleanup]
        public void CloseDown()
        {
            repo = null;
        }

        [TestMethod]
        public void GetPaymentsByAmount_50_Returns4()
        {
            //Arrange
            var amount = 50.00;

            //Act
            var actual = repo.GetPaymentsByAmount(amount).ToList().Count();
            var expected = 4;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPaymentsByDate_03062018_Returns2()
        {
            //Arrange
            var dateOfPayment = DateTime.Parse("03/06/2018");

            //Act
            var actual = repo.GetPaymentsByDate(dateOfPayment).ToList().Count();
            var expected = 2;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPaymentsByDate_01011900_Returns0()
        {
            //Arrange
            var dateOfPayment = DateTime.Parse("01/01/1900");

            //Act
            var actual = repo.GetPaymentsByDate(dateOfPayment).ToList().Count();
            var expected = 0;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPaymentsByDateRange_01062018to25062018_Returns4()
        {
            //Arrange
            var datefrom = DateTime.Parse("01/06/2018");
            var dateTo = DateTime.Parse("25/06/2018");

            //Act
            var actual = repo.GetPaymentsByDateRange(datefrom, dateTo).ToList().Count();
            var expected = 4;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
