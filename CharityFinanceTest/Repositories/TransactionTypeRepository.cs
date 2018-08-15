using FinanceEntities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositories
{
    public abstract class TransactionTypeRepository<T> : ITransactionTypeRepository<T> where T : struct
    {
        protected SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            AttachDBFilename = @"C:\Users\pc298\source\repos\charity-finance\charity-finance\CharityFinanceTest\Repositories\FinanceDB.mdf",
            DataSource = @"(localdb)\MSSQLLocalDB",
            IntegratedSecurity = true,
            ConnectTimeout = 30
        };

        protected string addCommandText;
        protected string deleteCommandText;

        public void AddTransactionType(TransactionType transactionType)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(addCommandText, conn);

                conn.Open();

                command.Parameters.AddWithValue("@Description", transactionType.Description);
                command.Parameters.AddWithValue("@LongDescription", transactionType.LongDescription);
            }
        }

        public TransactionType FindById(int id, string table)
        {
            string commandText = $"SELECT Id, Description, LongDescription FROM {table} WHERE Id = {id}";

            TransactionType transactionType = new TransactionType();

            using (SqlConnection conn = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(commandText, conn);

                conn.Open();

                transactionType = CreateTransactionType(transactionType, command);
            }

            return transactionType;
        }

        public virtual TransactionType FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public virtual IList<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(TransactionType transactionType)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(deleteCommandText, conn);

                conn.Open();

                command.Parameters.AddWithValue("@Id", transactionType.Id);

                command.ExecuteNonQuery();
            }
        }

        protected TransactionType CreateTransactionType(TransactionType transactionType, SqlCommand command)
        {
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    transactionType.Id = (int)dataReader["Id"];
                    transactionType.Description = (string)dataReader["Description"];
                    transactionType.LongDescription = (string)dataReader["LongDescription"];
                }
            }

            return transactionType;
        }
    }
}