using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceEntities
{
    public class Income
    {
        public DateTime Date{ get; set; }
        public string Description { get; set; }
        public PaymentTypes PaymentType { get; set; }
        public string PayingInSlip { get; set; }
        public Double Amount { get; set; }
        public BudgetTypes BudgetType { get; set; }
        public GiftAidStatus GiftAidStatus { get; set; }
    }

    public enum PaymentTypes
    {
        CHQ,
        BAC,
        SO,
        CASH
    }

    public enum BudgetTypes
    {
        GeneralIncome
    }

    public enum GiftAidStatus
    {
        NotGiftAid,
        GiftAid
    }
}
