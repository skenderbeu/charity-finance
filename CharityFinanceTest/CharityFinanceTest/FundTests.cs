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
            FundRepository repo = new FundRepository();
            var fundName = "Building Fund";

            //Act
            Fund actual = repo.GetFundByName(fundName);

            //Assert
            Assert.IsInstanceOfType(actual, typeof(Fund));
        }
    }
}
