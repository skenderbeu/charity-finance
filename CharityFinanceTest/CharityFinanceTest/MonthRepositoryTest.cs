using FinanceEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;

namespace CharityFinanceTests
{
    [TestClass]
    public class MonthRepositoryTests
    {
        private IMonthRepository repo;

        [TestInitialize]
        public void Setup()
        {
            repo = new MonthRepository(MockPaymentsMonthRepo.Payments(), MockIncomes.Incomes());
        }

        [TestCleanup]
        public void CloseDown()
        {
            repo = null;
        }

        [TestMethod]
        public void GetPaymentsTotalByMonth_June2018_Returns200()
        {
            //Arrange
            var month = Month.June;
            var year = 2018;

            //Act
            var actual = repo.GetPaymentsTotalByMonth(month, year);
            var expected = 200.00;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPaymentsTotalByMonth_May2018_Returns0()
        {
            //Arrange
            var month = Month.May;
            var year = 2018;

            //Act
            var actual = repo.GetPaymentsTotalByMonth(month, year);
            var expected = 0.00;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Month has not been set properly")]
        public void GetPaymentsTotalByMonth_NotSet2018_throwsException()
        {
            //Arrange
            var month = Month.NotSet;
            var year = 2018;

            //Act
            var actual = repo.GetPaymentsTotalByMonth(month, year);
        }

        [TestMethod]
        public void GetIncomeTotalByMonth_June2018_Returns0()
        {
            //Arrange
            var month = Month.June;
            var year = 2018;

            //Act
            var actual = repo.GetIncomeTotalByMonth(month, year);
            var expected = 0.00;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetIncomeTotalByMonth_May2018_Returns500()
        {
            //Arrange
            var month = Month.May;
            var year = 2018;

            //Act
            var actual = repo.GetIncomeTotalByMonth(month, year);
            var expected = 500.00;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Month has not been set properly")]
        public void GetIncomeTotalByMonth_NotSet2018_throwsException()
        {
            //Arrange
            var month = Month.NotSet;
            var year = 2018;

            //Act
            var actual = repo.GetIncomeTotalByMonth(month, year);
        }

        [TestMethod]
        public void GetBankClearedPaymentsByMonth_June2018_Returns100()
        {
            //Arrange
            var month = Month.June;
            var year = 2018;

            //Act
            var actual = repo.GetBankedClearedPaymentsTotalByMonth(month, year);
            var expected = 100.00;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBankClearedIncomeByMonth_May2018_Returns200()
        {
            //Arrange
            var month = Month.May;
            var year = 2018;

            //Act
            var actual = repo.GetBankedClearedIncomeTotalByMonth(month, year);
            var expected = 200.00;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOSChequesAmountByMonth_June2018_Returns250()
        {
            //Arrange
            var month = Month.June;
            var year = 2018;

            //Act
            var actual = repo.GetOSChequesAmountByMonth(month, year);
            var expected = 50.00;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOSPaidInAmountByMonth_May2018_Returns200()
        {
            //Arrange
            var month = Month.May;
            var year = 2018;

            //Act
            var actual = repo.GetOSPaidInAmountByMonth(month, year);
            var expected = 200.00;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}