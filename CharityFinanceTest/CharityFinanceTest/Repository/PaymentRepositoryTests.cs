using FinanceEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharityFinanceTests
{
    [TestClass]
    public class PaymentRepositoryTests
    {
        private IRepository<Payment> repo;
        private DateTime DATERECIEVED;
        private string DESCRIPTION;
        private PaymentType PAYMENTTYPE_TOADD;
        private PaymentType PAYMENTTYPE;
        private double AMOUNT;
        private BudgetType BUDGETTYPE_TOADD;
        private BudgetType BUDGETTYPE;
        private string NOTE;
        private bool BANKCLEARED;
        private FundType FUNDTYPE_TOADD;
        private FundType FUNDTYPE;
        private SpendType SPENDTYPE_TOADD;
        private SpendType SPENDTYPE;
        private string CHEQUENUMBER;

        private PaymentTypeRepository paymentTypeRepository;
        private BudgetTypeRepository budgetTypeRepository;
        private FundTypeRepository fundTypeRepository;
        private SpendTypeRepository spendTypeRepository;

        [TestInitialize]
        public void Setup()
        {
            repo = new PaymentRepository<Payment>();
            InitialiseParameters();

            CreateTransactionTypeRows();
        }

        [TestCleanup]
        public void CloseDown()
        {
            repo = null;

            DeleteTransactionTypeRows();

            paymentTypeRepository = null;
            fundTypeRepository = null;
            budgetTypeRepository = null;
        }

        private void CreateTransactionTypeRows()
        {
            paymentTypeRepository = new PaymentTypeRepository();
            fundTypeRepository = new FundTypeRepository();
            budgetTypeRepository = new BudgetTypeRepository();
            spendTypeRepository = new SpendTypeRepository();

            var paymentTypeId = paymentTypeRepository.Add(PAYMENTTYPE_TOADD);
            var fundTypeId = fundTypeRepository.Add(FUNDTYPE_TOADD);
            var budgetTypeId = budgetTypeRepository.Add(BUDGETTYPE_TOADD);
            var spendTypeId = spendTypeRepository.Add(SPENDTYPE_TOADD);

            PAYMENTTYPE = paymentTypeRepository.GetById(paymentTypeId);
            BUDGETTYPE = budgetTypeRepository.GetById(budgetTypeId);
            FUNDTYPE = fundTypeRepository.GetById(fundTypeId);
            SPENDTYPE = spendTypeRepository.GetById(spendTypeId);
        }

        private void DeleteTransactionTypeRows()
        {
            paymentTypeRepository.Remove(PAYMENTTYPE);
            fundTypeRepository.Remove(FUNDTYPE);
            budgetTypeRepository.Remove(BUDGETTYPE);
            spendTypeRepository.Remove(SPENDTYPE);
        }

        private void InitialiseParameters()
        {
            DATERECIEVED = new DateTime(2018, 8, 7);
            DESCRIPTION = "Builder and Sons";
            AMOUNT = 520.00;
            PAYMENTTYPE_TOADD = new PaymentType()
            {
                Id = Guid.NewGuid(),
                Description = "CHQ",
                LongDescription = "Cheque"
            };
            BUDGETTYPE_TOADD = new BudgetType()
            {
                Id = Guid.NewGuid(),
                Description = "Building",
                LongDescription = "Building Maintenance"
            };
            FUNDTYPE_TOADD = new FundType()
            {
                Id = Guid.NewGuid(),
                Description = "Building",
                LongDescription = "Building Fund"
            };
            SPENDTYPE_TOADD = new SpendType()
            {
                Id = Guid.NewGuid(),
                Description = "Capital",
                LongDescription = "Capital"
            };
            NOTE = "";
            BANKCLEARED = false;
            CHEQUENUMBER = "000123";
        }

        [TestMethod]
        [TestCategory("IntegrationTests")]
        public void PaymentCrud()
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
            Payment payment = new Payment()
            {
                Date = DATERECIEVED,
                Description = DESCRIPTION,
                Amount = AMOUNT,
                PaymentType = PAYMENTTYPE,
                BudgetType = BUDGETTYPE,
                Notes = NOTE,
                BankCleared = BANKCLEARED,
                FundType = FUNDTYPE,
                SpendType = SPENDTYPE,
                ChequeNumber = CHEQUENUMBER
            };

            //Act
            payment.Id = repo.Add(payment);

            //Assert
            Assert.AreNotEqual(0, payment.Id, "Creating new record does not return id");

            return payment.Id;
        }

        private void Update(Guid id)
        {
            // Arrange
            Payment payment = repo.GetById(id);
            payment.Description = "Test Change";

            // Act
            repo.Update(payment);

            Payment updatedPayment = repo.GetById(id);

            // Assert
            Assert.AreEqual("Test Change", updatedPayment.Description, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IList<Payment> payment = repo.GetAll();

            // Assert
            Assert.IsTrue(payment.Count() > 0, "GetAll returned no items.");
        }

        private void GetByID(Guid id)
        {
            // Act
            Payment payment = repo.GetById(id);

            // Assert
            Assert.IsNotNull(payment.Description, "GetByID returned null.");
            Assert.AreEqual(id, payment.Id);
            Assert.AreEqual(DESCRIPTION, payment.Description);
            Assert.AreEqual(AMOUNT, payment.Amount);
            Assert.AreEqual(CHEQUENUMBER, payment.ChequeNumber);
            Assert.AreEqual(PAYMENTTYPE, payment.PaymentType);
            Assert.AreEqual(BUDGETTYPE, payment.BudgetType);
            Assert.AreEqual(FUNDTYPE, payment.FundType);
            Assert.AreEqual(SPENDTYPE, payment.SpendType);
            Assert.AreEqual(NOTE, payment.Notes);
            Assert.AreEqual(BANKCLEARED, payment.BankCleared);
            Assert.AreEqual(DATERECIEVED, payment.Date);
        }

        private void Delete(Guid id)
        {
            // Arrange
            Payment payment = repo.GetById(id);

            // Act
            repo.Remove(payment);
            payment = repo.GetById(id);

            // Assert
            Assert.IsNull(payment, "Record is not deleted.");
        }
    }
}