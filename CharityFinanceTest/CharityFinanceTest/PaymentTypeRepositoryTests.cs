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
        private ITransactionTypeRepository<TransactionType> repo;
        private string DESCRIPTION;
        private string LONG_DESCRIPTION;

        [TestInitialize]
        public void Setup()
        {
            repo = new PaymentTypeRepository();
            InitialiseParameters();
        }

        [TestCleanup]
        public void CloseDown()
        {
            repo = null;
        }

        private void InitialiseParameters()
        {
            DESCRIPTION = "TST";
            LONG_DESCRIPTION = "Test Type";
        }

        [TestMethod]
        [TestCategory("IntegrationTests")]
        public void CompetitionCrud()
        {
            int newId = Create();
            //    GetByID(newID);
            //    GetAll();
            //    Update(newID);
            Delete(newId);
        }

        private int Create()
        {
            //Arrange
            TransactionType paymentType = new TransactionType
            {
                Description = DESCRIPTION,
                LongDescription = LONG_DESCRIPTION
            };

            //Act
            repo.AddTransactionType(paymentType);

            //Assert
            Assert.AreNotEqual(int.MinValue, paymentType.Id, "Creating new record does not return id");

            return paymentType.Id;
        }

        private void Delete(int id)
        {
            // Arrange
            TransactionType paymentType = repo.FindById(id);

            // Act
            repo.Remove(paymentType);
            paymentType = repo.FindById(id);

            // Assert
            Assert.IsNull(paymentType.Description, "Record is not deleted.");
        }

        //[TestMethod]
        //public void GetPaymentTypes_Call_Return5Results()
        //{
        //    //Arrange

        //    //Act
        //    var actual = repo.GetTypes().Count();
        //    var expected = 5;

        //    //Assert
        //    Assert.AreEqual(expected, actual);
        //}
    }
}