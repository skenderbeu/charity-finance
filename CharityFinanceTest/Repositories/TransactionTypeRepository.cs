using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositories
{
    public class TransactionTypeRepository<T> : ITransactionTypeRepository<T> where T : struct
    {
        protected SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            AttachDBFilename = @"C:\Users\pc298\source\repos\charity-finance\charity-finance\CharityFinanceTest\Repositories\FinanceDB.mdf",
            DataSource = @"(localdb)\MSSQLLocalDB",
            IntegratedSecurity = true,
            ConnectTimeout = 30
        };

        protected string addCommandText;

        public TransactionTypeRepository()
        {
        }

        public void AddTransactionType(string description, string longDescription)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(addCommandText, conn);

                conn.Open();

                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@LongDescription", longDescription);
            }
        }

        public virtual IList<T> GetTypes()
        {
            throw new System.NotImplementedException();
        }
    }
}