using FinanceDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoriesTest
{
    [TestClass]
    public class SpendTypeRepositoryTests
    {
        private ITransactionTypeRepository<SpendType> repo;
        private string DESCRIPTION;
        private string LONG_DESCRIPTION;

        [TestInitialize]
        public void Setup()
        {
            repo = new SpendTypeRepository();
            InitialiseParameters();
        }

        [TestCleanup]
        public void CloseDown()
        {
            repo = null;
        }

        private void InitialiseParameters()
        {
            DESCRIPTION = "Test";
            LONG_DESCRIPTION = "Test Type";
        }

        [TestMethod]
        [TestCategory("IntegrationTests")]
        public void SpendTypeCrud()
        {
            Guid newId = Create();
            GetByID(newId);
            GetAll();
            Update(newId);
            Delete(newId);
        }

        private Guid Create()
        {
            //Arrange
            SpendType spendType = new SpendType
            {
                Description = DESCRIPTION,
                LongDescription = LONG_DESCRIPTION
            };

            //Act
            spendType.Id = repo.Add(spendType);

            //Assert
            Assert.AreNotEqual(0, spendType.Id, "Creating new record does not return id");

            return spendType.Id;
        }

        private void Update(Guid id)
        {
            // Arrange
            SpendType spendType = repo.GetById(id);
            spendType.LongDescription = "Test Change";

            // Act
            repo.Update(spendType);

            SpendType updatedSpendType = repo.GetById(id);

            // Assert
            Assert.AreEqual("Test Change", updatedSpendType.LongDescription, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IList<SpendType> spendTypes = repo.GetAll();

            // Assert
            Assert.IsTrue(spendTypes.Count() > 0, "GetAll returned no items.");
        }

        private void GetByID(Guid id)
        {
            // Act
            SpendType spendType = repo.GetById(id);

            // Assert
            Assert.IsNotNull(spendType.Description, "GetByID returned null.");
            Assert.AreEqual(id, spendType.Id);
            Assert.AreEqual(DESCRIPTION, spendType.Description);
            Assert.AreEqual(LONG_DESCRIPTION, spendType.LongDescription);
        }

        private void Delete(Guid id)
        {
            // Arrange
            SpendType spendType = repo.GetById(id);

            // Act
            repo.Remove(spendType);
            spendType = repo.GetById(id);

            // Assert
            Assert.IsNull(spendType, "Record is not deleted.");
        }
    }
}