//using FinanceEntities;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Repositories;
//using System;
//using System.Linq;

//namespace CharityFinanceTests
//{
//    [TestClass]
//    public class PaymentRepositoryTests
//    {
//        private IPaymentRepository repo;

//        [TestInitialize]
//        public void Setup()
//        {
//            repo = new PaymentRepository(MockPayments.Payments());
//        }

//        [TestCleanup]
//        public void CloseDown()
//        {
//            repo.Dispose();
//            repo = null;
//        }

//        [TestMethod]
//        public void GetPaymentsByAmount_50_Returns4()
//        {
//            //Arrange
//            var amount = 50.00;

//            //Act
//            var actual = repo.GetPaymentsByAmount(amount).ToList().Count();
//            var expected = 4;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetPaymentsByAmountWithDate_50_Returns4()
//        {
//            //Arrange
//            var amount = 50.00;
//            var dateOfPayment = DateTime.Parse("03/06/2018");

//            var payments = repo.GetPaymentsByDate(dateOfPayment);

//            //Act
//            var actual = repo.GetPaymentsByAmount(amount, payments).ToList().Count();
//            var expected = 2;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetPaymentsByDate_03062018_Returns2()
//        {
//            //Arrange
//            var dateOfPayment = DateTime.Parse("03/06/2018");

//            //Act
//            var actual = repo.GetPaymentsByDate(dateOfPayment).ToList().Count();
//            var expected = 2;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetPaymentsByDate_01011900_Returns0()
//        {
//            //Arrange
//            var dateOfPayment = DateTime.Parse("01/01/1900");

//            //Act
//            var actual = repo.GetPaymentsByDate(dateOfPayment).ToList().Count();
//            var expected = 0;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetPaymentsByDateRange_01062018to25062018_Returns4()
//        {
//            //Arrange
//            var datefrom = DateTime.Parse("01/06/2018");
//            var dateTo = DateTime.Parse("25/06/2018");

//            //Act
//            var actual = repo.GetPaymentsByDateRange(datefrom, dateTo).ToList().Count();
//            var expected = 4;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetPaymentsByBudgetType_Building_Returns2()
//        {
//            //Arrange
//            var budgetType = BudgetTypes.Building;

//            //Act
//            var actual = repo.GetPaymentsByBudgetType(budgetType).ToList().Count();
//            var expected = 2;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetPaymentsByBudgetTypeWithDate_Building_Returns2()
//        {
//            //Arrange
//            var budgetType = BudgetTypes.Building;
//            var dateOfPayment = DateTime.Parse("03/06/2018");

//            var payments = repo.GetPaymentsByDate(dateOfPayment);

//            //Act
//            var actual = repo.GetPaymentsByBudgetType(budgetType, payments).ToList().Count();
//            var expected = 1;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetPaymentsByPaymentType_DDR_Returns4()
//        {
//            //Arrange
//            var paymentType = PaymentTypes.DDR;

//            //Act
//            var actual = repo.GetPaymentsByPaymentType(paymentType).ToList().Count();
//            var expected = 4;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetPaymentsByPaymentTypeWithDate_DDR_Returns2()
//        {
//            //Arrange
//            var paymentType = PaymentTypes.DDR;
//            var dateOfPayment = DateTime.Parse("03/06/2018");

//            var payments = repo.GetPaymentsByDate(dateOfPayment);

//            //Act
//            var actual = repo.GetPaymentsByPaymentType(paymentType, payments).ToList().Count();
//            var expected = 2;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetPaymentsByDescription_Tax_Returns2()
//        {
//            //Arrange
//            var description = "Tax";

//            //Act
//            var actual = repo.GetPaymentsByDescription(description).ToList().Count();
//            var expected = 2;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetPaymentsByDescriptionWithDate_Tax_Returns1()
//        {
//            //Arrange
//            var description = "Tax";
//            var dateOfPayment = DateTime.Parse("03/06/2018");

//            var payments = repo.GetPaymentsByDate(dateOfPayment);

//            //Act
//            var actual = repo.GetPaymentsByDescription(description, payments).ToList().Count();
//            var expected = 1;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetPaymentsByDescription_tax_Returns2()
//        {
//            //Arrange
//            var description = "tax";

//            //Act
//            var actual = repo.GetPaymentsByDescription(description).ToList().Count();
//            var expected = 2;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetPaymentsByDescription_TAX_Returns2()
//        {
//            //Arrange
//            var description = "TAX";

//            //Act
//            var actual = repo.GetPaymentsByDescription(description).ToList().Count();
//            var expected = 2;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetPaymentsByDescription_Council__Tax_Returns2()
//        {
//            //Arrange
//            var description = "Council  Tax";

//            //Act
//            var actual = repo.GetPaymentsByDescription(description).ToList().Count();
//            var expected = 2;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }

//        [TestMethod]
//        public void GetPaymentsByDescription__Council_Tax_Returns2()
//        {
//            //Arrange
//            var description = " Council Tax";

//            //Act
//            var actual = repo.GetPaymentsByDescription(description).ToList().Count();
//            var expected = 2;

//            //Assert
//            Assert.AreEqual(expected, actual);
//        }
//    }
//}