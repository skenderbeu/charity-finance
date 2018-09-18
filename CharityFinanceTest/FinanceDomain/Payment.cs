namespace FinanceDomain
{
    public class Payment : Transaction
    {
        public virtual SpendType SpendType { get; set; }
        public virtual string ChequeNumber { get; set; }

        public override bool FieldsValidated()
        {
            if (SpendType != null)
            {
                return base.FieldsValidated();
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"Payment {Description} made {Date} for {Amount} from budget {BudgetType.LongDescription}";
        }
    }
}