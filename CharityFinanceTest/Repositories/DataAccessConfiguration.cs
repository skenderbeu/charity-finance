using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;

namespace Repositories
{
    public static class DataAccessConfiguration
    {
        private static Configuration NHibernateConfiguration()
        {
            var cfg = new Configuration();

            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionStringName = "fileDB";
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