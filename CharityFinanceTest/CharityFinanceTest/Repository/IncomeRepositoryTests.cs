using FinanceEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharityFinanceTests
{
    [TestClass]
    public class IncomeRepositoryTests
    {
        private IRepository<Income> repo;
        private DateTime DATERECIEVED;
        private string DESCRIPTION;
        private PaymentType PAYMENTTYPE_TOADD;
        private PaymentType PAYMENTTYPE;
        private double AMOUNT;
        private BudgetType BUDGETTYPE_TOADD;
        private BudgetType BUDGETTYPE;
        private GiftAidStatus GIFTAIDSTATUS;
        private string PAYINGINSLIP;
        private string NOTE;
        private bool BANKCLEARED;
        private FundType FUNDTYPE_TOADD;
        private FundType FUNDTYPE;

        private PaymentTypeRepository paymentTypeRepository;
        private BudgetTypeRepository budgetTypeRepository;
        private FundTypeRepository fundTypeRepository;

        [TestInitialize]
        public void Setup()
        {
            repo = new IncomeRepository<Income>();
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
            DESCRIPTION = "Offering 7/8/2018";
            AMOUNT = 230.00;
            PAYMENTTYPE_TOADD = new PaymentType()
            {
                Id = Guid.NewGuid(),
                Description = "CSH",
                LongDescription = "Cash"
            };
            BUDGETTYPE_TOADD = new BudgetType()
            {
                Id = Guid.NewGuid(),
                Description = "GeneralIncome",
                LongDescription = "General Income"
            };
            FUNDTYPE_TOADD = new FundType()
            {
                Id = Guid.NewGuid(),
                Description = "Revenue",
                LongDescription = "Revenue"
            };
            GIFTAIDSTATUS = GiftAidStatus.NotGiftAid;
            PAYINGINSLIP = "000124";
            NOTE = "Offering taken in the evening";
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
            Income income = new Income()
            {
                Date = DATERECIEVED,
                Description = DESCRIPTION,
                Amount = AMOUNT,
                PaymentType = PAYMENTTYPE,
                BudgetType = BUDGETTYPE,
                GiftAidStatus = GIFTAIDSTATUS,
                PayingInSlip = PAYINGINSLIP,
                Notes = NOTE,
                BankCleared = BANKCLEARED,
                FundType = FUNDTYPE
            };

            //Act
            income.Id = repo.Add(income);

            //Assert
            Assert.AreNotEqual(0, income.Id, "Creating new record does not return id");

            return income.Id;
        }

        private void Update(Guid id)
        {
            // Arrange
            Income income = repo.GetById(id);
            income.Description = "Test Change";

            // Act
            repo.Update(income);

            Income updatedIncome = repo.GetById(id);

            // Assert
            Assert.AreEqual("Test Change", updatedIncome.Description, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IList<Income> income = repo.GetAll();

            // Assert
            Assert.IsTrue(income.Count() > 0, "GetAll returned no items.");
        }

        private void GetByID(Guid id)
        {
            // Act
            Income income = repo.GetById(id);

            // Assert
            Assert.IsNotNull(income.Description, "GetByID returned null.");
            Assert.AreEqual(id, income.Id);
            Assert.AreEqual(DESCRIPTION, income.Description);
            Assert.AreEqual(AMOUNT, income.Amount);
            Assert.AreEqual(PAYINGINSLIP, income.PayingInSlip);
            Assert.AreEqual(PAYMENTTYPE, income.PaymentType);
            Assert.AreEqual(BUDGETTYPE, income.BudgetType);
            Assert.AreEqual(FUNDTYPE, income.FundType);
            Assert.AreEqual(GIFTAIDSTATUS, income.GiftAidStatus);
            Assert.AreEqual(NOTE, income.Notes);
            Assert.AreEqual(BANKCLEARED, income.BankCleared);
            Assert.AreEqual(DATERECIEVED, income.Date);
        }

        private void Delete(Guid id)
        {
            // Arrange
            Income income = repo.GetById(id);

            // Act
            repo.Remove(income);
            income = repo.GetById(id);

            // Assert
            Assert.IsNull(income, "Record is not deleted.");
        }
    }
}