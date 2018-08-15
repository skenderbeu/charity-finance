using FinanceEntities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositories
{
    public class PaymentTypeRepository : TransactionTypeRepository<TransactionType>
    {
        public PaymentTypeRepository()
        {
            addCommandText = "INSERT INTO dbo.PaymentType ([Description], [LongDescription]) VALUES (@Description, @LongDescription)";
            deleteCommandText = "DELETE FROM dbo.PaymentType WHERE Id = @Id";
        }

        public override IList<TransactionType> GetAll()
        {
            List<TransactionType> paymentTypes = new List<TransactionType>();
            string commandText = "SELECT Id, Description, LongDescription FROM dbo.PaymentType";
            using (SqlConnection conn = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(commandText, conn);

                conn.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var paymentType = new TransactionType()
                        {
                            Id = (int)dataReader["Id"],
                            Description = (string)dataReader["Description"],
                            LongDescription = (string)dataReader["LongDescription"]
                        };

                        paymentTypes.Add(paymentType);
                    }
                }
            }

            return paymentTypes;
        }

        public override TransactionType FindById(int id)
        {
            string table = "dbo.PaymentType";

            return base.FindById(id, table);
        }
    }
}