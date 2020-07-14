using FinanceDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoriesTest
{
    [TestClass]
    public class PaymentRepositoryTests
    {
        private IRepository<Payment> paymentRepository;
        private DateTime DATERECIEVED;
        private TransactionDescription DESCRIPTION;
        private PaymentType PAYMENTTYPE_TOADD;
        private PaymentType PAYMENTTYPE;
        private double AMOUNT;
        private BudgetType BUDGETTYPE_TOADD;
        private BudgetType BUDGETTYPE;
        private Note NOTE;
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
        public void Setup(IRepository<Payment> paymentRepository,
            PaymentTypeRepository paymentTypeRepository,
            BudgetTypeRepository budgetTypeRepository,
            FundTypeRepository fundTypeRepository,
            SpendTypeRepository spendTypeRepository
            )
        {
            this.paymentRepository = paymentRepository;
            this.paymentTypeRepository = paymentTypeRepository;
            this.fundTypeRepository = fundTypeRepository;
            this.budgetTypeRepository = budgetTypeRepository;
            this.spendTypeRepository = spendTypeRepository;

            InitialiseParameters();

            CreateTransactionTypeRows();
        }

        [TestCleanup]
        public void CloseDown()
        {
            paymentRepository = null;

            DeleteTransactionTypeRows();

            paymentTypeRepository = null;
            fundTypeRepository = null;
            budgetTypeRepository = null;
        }

        private void CreateTransactionTypeRows()
        {
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
            DESCRIPTION = (TransactionDescription)"Builder and Sons";
            AMOUNT = 520.00;
            PAYMENTTYPE_TOADD = PaymentType.Create("CHQ", "Cheque").Value;
            BUDGETTYPE_TOADD = BudgetType.Create("Building", "Building Maintenance");
            FUNDTYPE_TOADD = FundType.Create("Building", "Building Fund");
            SPENDTYPE_TOADD = SpendType.Create("Capital", "Capital");
            NOTE = (Note)string.Empty;
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
            Payment payment = Payment.Create(
                DESCRIPTION,
                DATERECIEVED,
                PAYMENTTYPE,
                AMOUNT,
                BUDGETTYPE,
                SPENDTYPE,
                NOTE,
                CHEQUENUMBER,
                FUNDTYPE);

            //Act
            payment.Id = paymentRepository.Add(payment);

            //Assert
            Assert.AreNotEqual(0, payment.Id, "Creating new record does not return id");

            return payment.Id;
        }

        private void Update(Guid id)
        {
            // Arrange
            Payment payment = paymentRepository.GetById(id);
            payment.UpdateDescription((TransactionDescription)"Test Change");

            // Act
            paymentRepository.Update(payment);

            Payment updatedPayment = paymentRepository.GetById(id);

            // Assert
            Assert.AreEqual("Test Change", updatedPayment.Description, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IList<Payment> payment = paymentRepository.GetAll();

            // Assert
            Assert.IsTrue(payment.Count() > 0, "GetAll returned no items.");
        }

        private void GetByID(Guid id)
        {
            // Act
            Payment payment = paymentRepository.GetById(id);

            // Assert
            Assert.IsNotNull(payment.Description, "GetByID returned null.");
            Assert.AreEqual(id, payment.Id);
            Assert.AreEqual(DESCRIPTION, payment.Description);
            Assert.AreEqual(AMOUNT, payment.Amount);
            Assert.AreEqual(CHEQUENUMBER, payment.ChequeNumber);
            Assert.AreEqual(PAYMENTTYPE, payment.PaymentType);
            Assert.AreEqual(BUDGETTYPE, payment.BudgetType);
            Assert.AreEqual(SPENDTYPE, payment.SpendType);
            Assert.AreEqual(NOTE, payment.Notes);
            Assert.AreEqual(BANKCLEARED, payment.BankCleared);
            Assert.AreEqual(DATERECIEVED, payment.Date);
        }

        private void Delete(Guid id)
        {
            // Arrange
            Payment payment = paymentRepository.GetById(id);

            // Act
            paymentRepository.Remove(payment);
            payment = paymentRepository.GetById(id);

            // Assert
            Assert.IsNull(payment, "Record is not deleted.");
        }
    }
}