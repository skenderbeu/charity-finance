using FinanceEntities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositories
{
    public interface IFundTypeRepository
    {
        List<FundType> GetFundTypes();

        void AddFundType(string description, string longDescription);
    }

    public class FundTypeRepository : IFundTypeRepository
    {
        private SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            AttachDBFilename = @"C:\Users\pc298\source\repos\charity-finance\charity-finance\CharityFinanceTest\Repositories\FinanceDB.mdf",
            DataSource = @"(localdb)\MSSQLLocalDB",
            IntegratedSecurity = true,
            ConnectTimeout = 30
        };

        public FundTypeRepository()
        {
        }

        public void AddFundType(string description, string longDescription)
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

        public List<FundType> GetFundTypes()
        {
            List<FundType> fundTypes = new List<FundType>();
            string commandText = "SELECT Id, Description, LongDescription FROM dbo.FundType";
            using (SqlConnection conn = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(commandText, conn);

                conn.Open();

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var fundType = new FundType()
                        {
                            Id = (int)dataReader["Id"],
                            Description = (string)dataReader["Description"],
                            LongDescription = (string)dataReader["LongDescription"]
                        };

                        fundTypes.Add(fundType);
                    }
                }
            }

            return fundTypes;
        }
    }
}