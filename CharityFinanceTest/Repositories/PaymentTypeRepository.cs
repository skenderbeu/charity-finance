using FinanceEntities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositories
{
    public class PaymentTypeRepository : TransactionTypeRepository<PaymentType>
    {
        public PaymentTypeRepository()
        {
            addCommandText = "INSERT INTO dbo.PaymentType ([Description], [LongDescription]) VALUES (@Description, @LongDescription)";
        }

        public override IList<PaymentType> GetTypes()
        {
            List<PaymentType> paymentTypes = new List<PaymentType>();
            string commandText = "SELECT Id, Description, LongDescription FROM dbo.PaymentType";
            using (SqlConnection conn = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(commandText, conn);

                conn.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var paymentType = new PaymentType()
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
    }
}