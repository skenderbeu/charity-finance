using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinanceEntities;
using Repositories;

namespace CharityFinanceTest
{
    [TestClass]
    public class FundTests
    {
        [TestMethod]
        public void FundRepository_GetFundByName_ReturnsFund()
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
        public void FundRepository_GetFundBalance_ReturnsBalance100()
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
        public void FundRepository_GetFundBalance_ReturnsBalance200()
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
    }
}
