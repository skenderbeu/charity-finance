using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinanceEntities;
using Repositories;

namespace CharityFinanceTest
{
    [TestClass]
    public class FundRepositoryTests
    {
        [TestMethod]
        public void GetFundByName__BuildingFund_ReturnsTypeFund()
        {
            //Arrange
            IFundRepository repo = new MockFundRepository();
            var fundName = FundTypes.BuildingFund;

            //Act
            Fund actual = repo.GetFundByName(fundName);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Fund));
        }


        [TestMethod]
        public void GetFundBalance_FundBuildingFund_ReturnsBalance100()
        {
            //Arrange
            IFundRepository repo = new MockFundRepository();
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
            IFundRepository repo = new MockFundRepository();
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
            IFundRepository repo = new MockFundRepository();
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
            IFundRepository repo = new MockFundRepository();
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
            IFundRepository repo = new MockFundRepository();
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
            IFundRepository repo = new MockFundRepository();
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
