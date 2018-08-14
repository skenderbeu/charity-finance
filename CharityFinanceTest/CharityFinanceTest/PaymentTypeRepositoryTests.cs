using System;
using System.Linq;
using FinanceEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;

namespace CharityFinanceTests
{
    [TestClass]
    public class PaymentTypeRepositoryTests
    {
        private ITransactionTypeRepository<PaymentType> repo;

        [TestInitialize]
        public void Setup()
        {
            repo = new PaymentTypeRepository();
        }

        [TestCleanup]
        public void CloseDown()
        {
            repo = null;
        }

        [TestMethod]
        public void GetPaymentTypes_Call_Return5Results()
        {
            //Arrange

            //Act
            var actual = repo.GetTypes().Count();
            var expected = 5;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}