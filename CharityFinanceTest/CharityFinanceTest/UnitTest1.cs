using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;

namespace CharityFinanceTest
{
    [TestClass]
    public class MonthRepositoryTests
    {

        IMonthRepository repo;

        [TestInitialize]
        public void Setup()
        {
            repo = new MonthRepository(MockPayments.Payments(), MockIncomes.Incomes());
        }

        [TestCleanup]
        public void CloseDown()
        {
            repo = null;
        }

    
    }
}
