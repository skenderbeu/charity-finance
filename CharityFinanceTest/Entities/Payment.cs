namespace FinanceEntities
{
    public class Payment : Transaction
    {
        public SpendTypes SpendType { get; set; }

        public override bool FieldsValidated()
        {
            if (SpendType != SpendTypes.NotSet)
            {
                return base.FieldsValidated();
            }
            else
            {
                return false;
            }
        }
    }
}