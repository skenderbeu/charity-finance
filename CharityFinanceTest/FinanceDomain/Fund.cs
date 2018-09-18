namespace FinanceDomain
{
    public class Fund
    {
        public Fund(string fundName, double balance)
        {
            FundName = fundName;
            Balance = balance;
        }

        public string FundName { get; private set; }
        public double Balance { get; private set; }
    }
}