using System;
using System.IO;

namespace ExcelServices
{
    public class IncomeSheetDTO
    {
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string PaymentType { get; set; }
        public Double Amount { get; set; }
        public string BudgetType { get; set; }
        public string Notes { get; set; }
        public string FundType { get; set; }
        public Boolean BankCleared { get; set; }
        public string PayingInSlip { get; set; }
        public string GiftAidStatus { get; set; }
    }

    public class ExcelFile
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public FileInfo FilePath { get; set; }
        public string SheetName { get; set; }
    }
}