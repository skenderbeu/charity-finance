﻿using FinanceDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoriesTest
{
    [TestClass]
    public class PaymentTypeRepositoryTests
    {
        private ITransactionTypeRepository<PaymentType> repo;
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
            PaymentType paymentType = PaymentType.Create(DESCRIPTION, LONG_DESCRIPTION).Value;

            //Act
            paymentType.Id = repo.Add(paymentType);

            //Assert
            Assert.AreNotEqual(0, paymentType.Id, "Creating new record does not return id");

            return paymentType.Id;
        }

        private void Update(Guid id)
        {
            // Arrange
            PaymentType paymentType = repo.GetById(id);
            paymentType.LongDescription = "Test Change";

            // Act
            repo.Update(paymentType);

            PaymentType updatedPaymentType = repo.GetById(id);

            // Assert
            Assert.AreEqual("Test Change", updatedPaymentType.LongDescription, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IList<PaymentType> paymentTypes = repo.GetAll();

            // Assert
            Assert.IsTrue(paymentTypes.Count() > 0, "GetAll returned no items.");
        }

        private void GetByID(Guid id)
        {
            // Act
            PaymentType paymentType = repo.GetById(id);

            // Assert
            Assert.IsNotNull(paymentType.Description, "GetByID returned null.");
            Assert.AreEqual(id, paymentType.Id);
            Assert.AreEqual(DESCRIPTION, paymentType.Description);
            Assert.AreEqual(LONG_DESCRIPTION, paymentType.LongDescription);
        }

        private void Delete(Guid id)
        {
            // Arrange
            PaymentType paymentType = repo.GetById(id);

            // Act
            repo.Remove(paymentType);
            paymentType = repo.GetById(id);

            // Assert
            Assert.IsNull(paymentType, "Record is not deleted.");
        }
    }
}