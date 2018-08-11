using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinanceEntities;
using Repositories;

namespace CharityFinanceTests
{
    [TestClass]
    public class FundRepositoryTests
    {
        IFundRepository repo;

        [TestInitialize]
        public void Setup()
        {
            repo = new FundRepository(
                MockIncomes.Incomes(), 
                MockPayments.Payments());
        }

        [TestCleanup]
        public void CloseDown()
        {
            repo = null;
        }

        [TestMethod]
        public void GetFundByName__BuildingFund_ReturnsTypeFund()
        {
            //Arrange
            
            var fundName = FundTypes.BuildingFund;

            //Act
            Fund actual = repo.GetFundByName(fundName);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Fund));
        }

        [TestMethod]
        public void GetFundByName__MessyChurch_ReturnsTypeFund()
        {
            //Arrange

            var fundName = FundTypes.MessyChurch;

            //Act
            Fund actual = repo.GetFundByName(fundName);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Fund));
        }


        [TestMethod]
        public void GetFundBalance_FundBuildingFund_ReturnsBalance100()
        {
            //Arrange
            var fundName = FundTypes.BuildingFund;

            //Act
            Fund actual = repo.GetFundByName(fundName);
            double expected = 100.00;

            //Assert
            Assert.AreEqual(expected, actual.Balance);
        }


        [TestMethod]
        public void GetFundByName_FundMessyChurch_ReturnsBalance200()
        {
            //Arrange
            var fundName = FundTypes.MessyChurch;

            //Act
            Fund actual = repo.GetFundByName(fundName);
            double expected = 200.00;

            //Assert
            Assert.AreEqual(expected, actual.Balance);
        }

        [TestMethod]
        public void GetFundBalanceByDate_Date010518_ReturnsBalance200()
        {
            //Arrange
            var fundName = FundTypes.MessyChurch;

            DateTime date;
            DateTime.TryParse("01/05/2018", out date);

            //Act
            Fund actual = repo.GetFundByNameAndDate(fundName, date );
            double expected = 200.00;

            //Assert
            Assert.AreEqual(expected, actual.Balance);
        }

        [TestMethod]
        public void GetFundBalanceByDate_Date220518_ReturnsBalance300()
        {
            //Arrange
            var fundName = FundTypes.MessyChurch;

            DateTime date;
            DateTime.TryParse("22/05/2018", out date);

            //Act
            Fund actual = repo.GetFundByNameAndDate(fundName, date);
            double expected = 300.00;

            //Assert
            Assert.AreEqual(expected, actual.Balance);
        }

        [TestMethod]
        public void GetFundBalanceByDate_Date030618_ReturnsBalance250()
        {
            //Arrange
            var fundName = FundTypes.MessyChurch;

            DateTime date;
            DateTime.TryParse("03/06/2018", out date);

            //Act
            Fund actual = repo.GetFundByNameAndDate(fundName, date);
            double expected = 250.00;

            //Assert
            Assert.AreEqual(expected, actual.Balance);
        }

        [TestMethod]
        public void GetFundBalanceByDate_Date230618_ReturnsBalance200()
        {
            //Arrange
            var fundName = FundTypes.MessyChurch;

            DateTime date;
            DateTime.TryParse("23/06/2018", out date);

            //Act
            Fund actual = repo.GetFundByNameAndDate(fundName, date);
            double expected = 200.00;

            //Assert
            Assert.AreEqual(expected, actual.Balance);
        }
    }
}
