using System.Collections.Generic;

namespace FinanceEntities
{
    public struct PaymentType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
    }

    public struct BudgetType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
    }

    public struct FundType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
    }

    public struct SpendType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
    }
}