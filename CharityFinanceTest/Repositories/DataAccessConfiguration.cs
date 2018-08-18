using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Data.SqlClient;
using System.Reflection;

namespace Repositories
{
    public static class DataAccessConfiguration
    {
        private static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            AttachDBFilename = @"C:\Users\pc298\source\repos\charity-finance\charity-finance\CharityFinanceTest\Repositories\FinanceDB.mdf",
            DataSource = @"(localdb)\MSSQLLocalDB",
            IntegratedSecurity = true,
            ConnectTimeout = 30
        };

        public static string SQLDBConnectionString()
        {
            return sqlConnectionStringBuilder.ConnectionString;
        }

        public static Configuration NHibernateConfiguration()
        {
            var cfg = new Configuration();

            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = sqlConnectionStringBuilder.ConnectionString;
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            return cfg;
        }
    }
}