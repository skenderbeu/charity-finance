using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;
using System.Configuration;

namespace Repositories
{
    public static class DataAccessConfiguration
    {
        private static NHibernate.Cfg.Configuration NHibernateConfiguration()
        {
            var cfg = new NHibernate.Cfg.Configuration();

            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Data\FinanceDB.mdf";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
                x.Timeout = 10;
                x.LogSqlInConsole = true;
                x.LogFormattedSql = true;
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            return cfg;
        }

        public static ISessionFactory SessionFactory()
        {
            return NHibernateConfiguration().BuildSessionFactory();
        }
    }
}