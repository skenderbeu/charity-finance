﻿using FinanceDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoriesTest
{
    [TestClass]
    public class FundTypeRepositoryTests
    {
        private ITransactionTypeRepository<FundType> repo;
        private string DESCRIPTION;
        private string LONG_DESCRIPTION;

        [TestInitialize]
        public void Setup()
        {
            repo = new FundTypeRepository();
            InitialiseParameters();
        }

        [TestCleanup]
        public void CloseDown()
        {
            repo = null;
        }

        private void InitialiseParameters()
        {
            DESCRIPTION = "TestFund";
            LONG_DESCRIPTION = "Test Fund";
        }

        [TestMethod]
        [TestCategory("IntegrationTests")]
        public void PaymentTypeCrud()
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
            FundType fundType = FundType.Create(DESCRIPTION, LONG_DESCRIPTION);

            //Act
            fundType.Id = repo.Add(fundType);

            //Assert
            Assert.AreNotEqual(0, fundType.Id, "Creating new record does not return id");

            return fundType.Id;
        }

        private void Update(Guid id)
        {
            // Arrange
            FundType fundType = repo.GetById(id);
            fundType.LongDescription = "Test Change";

            // Act
            repo.Update(fundType);

            FundType updatedFundType = repo.GetById(id);

            // Assert
            Assert.AreEqual("Test Change", updatedFundType.LongDescription, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IList<FundType> fundTypes = repo.GetAll();

            // Assert
            Assert.IsTrue(fundTypes.Count() > 0, "GetAll returned no items.");
        }

        private void GetByID(Guid id)
        {
            // Act
            FundType fundType = repo.GetById(id);

            // Assert
            Assert.IsNotNull(fundType.Description, "GetByID returned null.");
            Assert.AreEqual(id, fundType.Id);
            Assert.AreEqual(DESCRIPTION, fundType.Description);
            Assert.AreEqual(LONG_DESCRIPTION, fundType.LongDescription);
        }

        private void Delete(Guid id)
        {
            // Arrange
            FundType fundType = repo.GetById(id);

            // Act
            repo.Remove(fundType);
            fundType = repo.GetById(id);

            // Assert
            Assert.IsNull(fundType, "Record is not deleted.");
        }
    }
}