using FinanceDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoriesTest
{
    [TestClass]
    public class IncomeRepositoryTests
    {
        private IRepository<Income> incomeRepository;
        private DateTime DATERECIEVED;
        private TransactionDescription DESCRIPTION;
        private PaymentType PAYMENTTYPE_TOADD;
        private PaymentType PAYMENTTYPE;
        private double AMOUNT;
        private BudgetType BUDGETTYPE_TOADD;
        private BudgetType BUDGETTYPE;
        private GiftAidStatus GIFTAIDSTATUS;
        private string PAYINGINSLIP;
        private Note NOTE;
        private bool BANKCLEARED;
        private FundType FUNDTYPE_TOADD;
        private FundType FUNDTYPE;

        private PaymentTypeRepository paymentTypeRepository;
        private BudgetTypeRepository budgetTypeRepository;
        private FundTypeRepository fundTypeRepository;

        [TestInitialize]
        public void Setup(IRepository<Income> incomeRepository,
            PaymentTypeRepository paymentTypeRepository,
            BudgetTypeRepository budgetTypeRepository,
            FundTypeRepository fundTypeRepository)
        {
            this.incomeRepository = incomeRepository;
            this.paymentTypeRepository = paymentTypeRepository;
            this.budgetTypeRepository = budgetTypeRepository;
            this.fundTypeRepository = fundTypeRepository;

            InitialiseParameters();

            CreateTransactionTypeRows();
        }

        [TestCleanup]
        public void CloseDown()
        {
            incomeRepository = null;

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

            PAYMENTTYPE = paymentTypeRepository.GetById(paymentTypeId);
            BUDGETTYPE = budgetTypeRepository.GetById(budgetTypeId);
            FUNDTYPE = fundTypeRepository.GetById(fundTypeId);
        }

        private void DeleteTransactionTypeRows()
        {
            paymentTypeRepository.Remove(PAYMENTTYPE);
            fundTypeRepository.Remove(FUNDTYPE);
            budgetTypeRepository.Remove(BUDGETTYPE);
        }

        private void InitialiseParameters()
        {
            DATERECIEVED = new DateTime(2018, 8, 7);
            DESCRIPTION = (TransactionDescription)"Offering 7/8/2018";
            AMOUNT = 230.00;
            PAYMENTTYPE_TOADD = PaymentType.Create("CSH", "Cash").Value;
            BUDGETTYPE_TOADD = BudgetType.Create("GeneralIncome", "General Income");
            FUNDTYPE_TOADD = FundType.Create("Revenue", "Revenue");
            GIFTAIDSTATUS = GiftAidStatus.NotGiftAid;
            PAYINGINSLIP = "000124";
            NOTE = (Note)"Offering taken in the evening";
            BANKCLEARED = false;
        }

        [TestMethod]
        [TestCategory("IntegrationTests")]
        public void IncomeCrud()
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

            Income income = Income.Create(
                DESCRIPTION,
                DATERECIEVED,
                PAYMENTTYPE,
                AMOUNT,
                BUDGETTYPE,
                NOTE,
                FUNDTYPE);

            income.GiftAidStatus = GIFTAIDSTATUS;
            income.PayingInSlip = PAYINGINSLIP;

            //Act
            income.Id = incomeRepository.Add(income);

            //Assert
            Assert.AreNotEqual(0, income.Id, "Creating new record does not return id");

            return income.Id;
        }

        private void Update(Guid id)
        {
            // Arrange
            Income income = incomeRepository.GetById(id);
            income.UpdateDescription((TransactionDescription)"Test Change");

            // Act
            incomeRepository.Update(income);

            Income updatedIncome = incomeRepository.GetById(id);

            // Assert
            Assert.AreEqual("Test Change", updatedIncome.Description, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IList<Income> income = incomeRepository.GetAll();

            // Assert
            Assert.IsTrue(income.Count() > 0, "GetAll returned no items.");
        }

        private void GetByID(Guid id)
        {
            // Act
            Income income = incomeRepository.GetById(id);

            // Assert
            Assert.IsNotNull(income.Description, "GetByID returned null.");
            Assert.AreEqual(id, income.Id);
            Assert.AreEqual(DESCRIPTION, income.Description);
            Assert.AreEqual(AMOUNT, income.Amount);
            Assert.AreEqual(PAYINGINSLIP, income.PayingInSlip);
            Assert.AreEqual(PAYMENTTYPE, income.PaymentType);
            Assert.AreEqual(BUDGETTYPE, income.BudgetType);
            Assert.AreEqual(GIFTAIDSTATUS, income.GiftAidStatus);
            Assert.AreEqual(NOTE, income.Notes);
            Assert.AreEqual(BANKCLEARED, income.BankCleared);
            Assert.AreEqual(DATERECIEVED, income.Date);
        }

        private void Delete(Guid id)
        {
            // Arrange
            Income income = incomeRepository.GetById(id);

            // Act
            incomeRepository.Remove(income);
            income = incomeRepository.GetById(id);

            // Assert
            Assert.IsNull(income, "Record is not deleted.");
        }
    }
}