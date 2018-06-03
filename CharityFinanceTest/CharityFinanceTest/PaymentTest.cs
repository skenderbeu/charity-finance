using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinanceEntities;

namespace CharityFinanceTests
{
    [TestClass]
    public class PaymentTests
    {
        [TestMethod]
        public void Payment_AddPayment()
        {
            Payment payment = new Payment
            {
                Date = DateTime.Parse("03/06/2018"),
                Description = "Council Tax",
                PaymentType = PaymentTypes.DDR,
                Amount = 210.00,
                BudgetType = BudgetTypes.CouncilTax,
                SpendType = SpendTypes.Revenue
            };

            var expected = "CouncilTax";
                
            var actual = payment.BudgetType.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
