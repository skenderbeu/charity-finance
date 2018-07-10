using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;

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
            var actual = repo.GetPaymentsByAmount(amount).Count;
            var expected = 4;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
