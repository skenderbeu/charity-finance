using FinanceEntities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Repositories
{
    public abstract class TransactionTypeRepository<T> : ITransactionTypeRepository<T> where T : TransactionType
    {
        public Guid Add(T transactionType)
        {
            Guid idCreated;
            using (var session = DataAccessConfiguration.SessionFactory().OpenSession())
            using (var trans = session.BeginTransaction())
            {
                idCreated = (Guid)session.Save(transactionType);
                trans.Commit();
            }

            return idCreated;
        }

        public T GetById(Guid id)
        {
            using (var session = DataAccessConfiguration.SessionFactory().OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var transactionType = session
                                        .Query<T>()
                                        .Where(x => x.Id == id)
                                        .FirstOrDefault();
                tx.Commit();

                return transactionType;
            }
        }

        public IList<T> GetAll()
        {
            IList<T> transactionTypes;

            using (var session = DataAccessConfiguration.SessionFactory().OpenSession())
            using (var tx = session.BeginTransaction())
            {
                transactionTypes = session.Query<T>().Select(x => x).ToList();
                tx.Commit();

                return transactionTypes;
            }
        }

        public void Update(T transactionType)
        {
            using (var session = DataAccessConfiguration.SessionFactory().OpenSession())
            using (var trans = session.BeginTransaction())
            {
                session.Update(transactionType);
                trans.Commit();
            }
        }

        public void Remove(T transactionType)
        {
            using (var session = DataAccessConfiguration.SessionFactory().OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.Delete(transactionType);
                tx.Commit();
            }
        }
    }
}