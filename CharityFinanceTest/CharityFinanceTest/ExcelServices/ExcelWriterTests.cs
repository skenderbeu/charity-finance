using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExcelServices;
using System.IO;
using FinanceEntities;
using System.Collections.Generic;

namespace CharityFinanceTests
{
    [TestClass]
    public class ExcelWriterTests
    {
        private ExcelWriter excelWriter;
        private ExcelFile excelFile;

        [TestInitialize]
        public void Setup()
        {
            excelWriter = new ExcelWriter();
            InitializeVariables();
        }

        [TestCleanup]
        public void CloseDown()
        {
            excelWriter = null;
        }

        private void InitializeVariables()
        {
            excelFile = new ExcelFile()
            {
                Author = "Peter Campbell",
                Title = "Main Balances",
                Subject = "Woodbank Community Church Finances",
                SheetName = "Income"
            };
        }

        [TestMethod]
        public void Write_Add20Cells_Read20Cells()
        {
            //Arrange
            excelFile.FilePath = new FileInfo(@"C:\TEMP\TestExcelFile2.xlsx");
            var incomeSheetDTO = new IncomeSheetDTO()
            {
                CreatedDate = DateTime.Parse("22/05/2018"),
                Description = "Offering 20/05/18",
                PaymentType = "CSH",
                Amount = 230.00,
                BudgetType = "GeneralIncome",
                GiftAidStatus = GiftAidStatus.NotGiftAid.ToString(),
                BankCleared = false,
                FundType = "Revenue",
                Notes = "Some Notes",
                PayingInSlip = "000675"
            };

            var rows = new List<IncomeSheetDTO>
            {
                incomeSheetDTO
            };

            //Act
            excelWriter.Write(excelFile, rows);
            var actual = excelWriter.Read(excelFile.FilePath.FullName).Count;
            var expected = 20;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}