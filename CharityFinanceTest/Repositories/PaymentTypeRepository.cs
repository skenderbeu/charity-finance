using FinanceEntities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositories
{
    public interface IPaymentTypeRepository
    {
        List<PaymentType> GetPaymentTypes();

        void AddPaymentType(string description, string longDescription);
    }

    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private List<PaymentType> paymentTypes;

        private SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            AttachDBFilename = @"C:\Users\pc298\source\repos\charity-finance\charity-finance\CharityFinanceTest\Repositories\FinanceDB.mdf"
        };

        public PaymentTypeRepository()
        {
        }

        public void AddPaymentType(string description, string longDescription)
        {
            string commandText = "INSERT INTO dbo.PaymentType ([Description], [LongDescription]) VALUES (@Description, @LongDescription)";
            using (SqlConnection conn = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(commandText, conn);

                conn.Open();

                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@LongDescription", longDescription);
            }
        }

        public List<PaymentType> GetPaymentTypes()
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