using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System.Linq;

namespace CharityFinanceTests
{
    [TestClass]
    public class IncomeRepositoryTests
    {
        IIncomeRepository repo;

        [TestInitialize]
        public void Setup()
        {
            repo = new IncomeRepository(MockIncomes.Incomes());
        }

        [TestCleanup]
        public void CloseDown()
        {
            repo = null;
        }

        [TestMethod]
        public void GetIncomeByAmount_100_Returns3()
        {
            //Arrange
            var amount = 100.00;

            //Act
            var actual = repo.GetIncomeByAmount(amount).ToList().Count();
            var expected = 3;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPaymentsByAmountWithDate_100_Returns2()
        {
            //Arrange
            var amount = 100.00;
            var dateOfPayment = DateTime.Parse("22/05/2018");

            var payments = repo.GetIncomeByDate(dateOfPayment);

            //Act
            var actual = repo.GetIncomeByAmount(amount, payments).ToList().Count();
            var expected = 2;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
