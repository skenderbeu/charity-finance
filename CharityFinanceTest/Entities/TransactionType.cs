namespace FinanceEntities
{
    public class TransactionType
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual string LongDescription { get; set; }
    }

    public class PaymentType : TransactionType { }

    public class FundType : TransactionType { }

    public class BudgetType : TransactionType { }

    public class SpendType : TransactionType { }
}