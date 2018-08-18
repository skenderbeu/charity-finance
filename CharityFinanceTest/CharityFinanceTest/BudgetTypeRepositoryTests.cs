using FinanceEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CharityFinanceTests
{
    [TestClass]
    public class BudgetTypeRepositoryTests
    {
        private ITransactionTypeRepository<BudgetType> repo;
        private string DESCRIPTION;
        private string LONG_DESCRIPTION;

        [TestInitialize]
        public void Setup()
        {
            repo = new BudgetTypeRepository();
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
        public void BudgetTypeCrud()
        {
            int newId = Create();
            GetByID(newId);
            GetAll();
            Update(newId);
            Delete(newId);
        }

        private int Create()
        {
            //Arrange
            BudgetType budgetType = new BudgetType
            {
                Description = DESCRIPTION,
                LongDescription = LONG_DESCRIPTION
            };

            //Act
            budgetType.Id = repo.Add(budgetType);

            //Assert
            Assert.AreNotEqual(0, budgetType.Id, "Creating new record does not return id");

            return budgetType.Id;
        }

        private void Update(int id)
        {
            // Arrange
            BudgetType budgetType = repo.GetById(id);
            budgetType.LongDescription = "Test Change";

            // Act
            repo.Update(budgetType);

            BudgetType updatedBudgetType = repo.GetById(id);

            // Assert
            Assert.AreEqual("Test Change", updatedBudgetType.LongDescription, "Record is not updated.");
        }

        private void GetAll()
        {
            // Act
            IList<BudgetType> budgetTypes = repo.GetAll();

            // Assert
            Assert.IsTrue(budgetTypes.Count() > 0, "GetAll returned no items.");
        }

        private void GetByID(int id)
        {
            // Act
            BudgetType budgetType = repo.GetById(id);

            // Assert
            Assert.IsNotNull(budgetType.Description, "GetByID returned null.");
            Assert.AreEqual(id, budgetType.Id);
            Assert.AreEqual(DESCRIPTION, budgetType.Description);
            Assert.AreEqual(LONG_DESCRIPTION, budgetType.LongDescription);
        }

        private void Delete(int id)
        {
            // Arrange
            BudgetType budgetType = repo.GetById(id);

            // Act
            repo.Remove(budgetType);
            budgetType = repo.GetById(id);

            // Assert
            Assert.IsNull(budgetType, "Record is not deleted.");
        }
    }
}