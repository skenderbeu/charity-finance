//using FinanceEntities;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;

//namespace Repositories
//{
//    public abstract class TransactionTypeADORepository<T> : ITransactionTypeRepository<T> where T : TransactionType
//    {
//        private readonly string table;
//        private readonly string insertSP;
//        private string connectionString;

//        public TransactionTypeADORepository(string table, string insertSP)
//        {
//            this.table = table;
//            this.insertSP = insertSP;
//            connectionString = DataAccessConfiguration.SQLDBConnectionString();
//        }

//        public int AddTransactionType(T entity)
//        {
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                SqlCommand command = new SqlCommand(insertSP, conn);

//                command.CommandType = CommandType.StoredProcedure;

//                conn.Open();

//                command.Parameters.Add(new SqlParameter("@description", entity.Description));
//                command.Parameters.Add(new SqlParameter("@longdescription", entity.LongDescription));

//                entity.Id = (int)command.ExecuteScalar();
//            }

//            return entity.Id;
//        }

//        public TransactionType GetById(int id)
//        {
//            string commandText = $"SELECT Id, Description, LongDescription FROM {table} WHERE Id = {id}";

//            TransactionType transactionType = new TransactionType();

//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                SqlCommand command = new SqlCommand(commandText, conn);

//                conn.Open();

//                transactionType = CreateSingle(transactionType, command);
//            }

//            return transactionType;
//        }

//        public IList<T> GetAll()
//        {
//            string commandText = "SELECT Id, Description, LongDescription FROM dbo.PaymentType";
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                SqlCommand command = new SqlCommand(commandText, conn);

//                conn.Open();
//                return CreateList(command);
//            }
//        }

//        public void Update(TransactionType transactionType)
//        {
//            string commandText = $"UPDATE {table} SET Description = @description, LongDescription = @longdescription WHERE Id = @Id";

//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                SqlCommand command = new SqlCommand(commandText, conn);

//                conn.Open();

//                command.Parameters.AddWithValue("@description", transactionType.Description);
//                command.Parameters.AddWithValue("@longdescription", transactionType.LongDescription);
//                command.Parameters.AddWithValue("@Id", transactionType.Id);

//                command.ExecuteNonQuery();
//            }
//        }

//        public void Remove(TransactionType transactionType)
//        {
//            string commandText = $"DELETE FROM {table} WHERE Id = @Id";

//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                SqlCommand command = new SqlCommand(commandText, conn);

//                conn.Open();

//                command.Parameters.AddWithValue("@Id", transactionType.Id);

//                command.ExecuteNonQuery();
//            }
//        }

//        private TransactionType CreateSingle(TransactionType transactionType, SqlCommand command)
//        {
//            using (SqlDataReader dataReader = command.ExecuteReader())
//            {
//                while (dataReader.Read())
//                {
//                    transactionType.Id = (int)dataReader["Id"];
//                    transactionType.Description = (string)dataReader["Description"];
//                    transactionType.LongDescription = (string)dataReader["LongDescription"];
//                }
//            }

//            return transactionType;
//        }

//        private IList<T> CreateList(SqlCommand command)
//        {
//            IList<T> transactionTypes = new List<T>();
//            using (SqlDataReader dataReader = command.ExecuteReader())
//            {
//                while (dataReader.Read())
//                {
//                    var transactionType = new TransactionType()
//                    {
//                        Id = (int)dataReader["Id"],
//                        Description = (string)dataReader["Description"],
//                        LongDescription = (string)dataReader["LongDescription"]
//                    };

//                    transactionTypes.Add(transactionType);
//                }
//            }

//            return transactionTypes;
//        }
//    }
//}