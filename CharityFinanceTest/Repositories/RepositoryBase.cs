using FinanceDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        public RepositoryBase()
        {
        }

        public Guid Add(T entity)
        {
            Guid idCreated;
            using (var session = DataAccessConfiguration.SessionFactory().OpenSession())
            using (var trans = session.BeginTransaction())
            {
                idCreated = (Guid)session.Save(entity);
                trans.Commit();
            }

            return idCreated;
        }

        public List<Guid> Add(IList<T> entities)
        {
            List<Guid> idsCreated = new List<Guid>();
            using (var session = DataAccessConfiguration.SessionFactory().OpenSession())
            using (var trans = session.BeginTransaction())
            {
                foreach (var transactionType in entities)
                {
                    idsCreated.Add((Guid)session.Save(entities));
                }
                trans.Commit();
            }

            return idsCreated;
        }

        public IList<T> GetAll()
        {
            IList<T> entities;

            using (var session = DataAccessConfiguration.SessionFactory().OpenSession())
            using (var tx = session.BeginTransaction())
            {
                entities = session.Query<T>().Select(x => x).ToList();
                tx.Commit();

                return entities;
            }
        }

        public IList<T> GetBy(Expression<Func<T, bool>> expression)
        {
            IList<T> entities;

            using (var session = DataAccessConfiguration.SessionFactory().OpenSession())
            using (var tx = session.BeginTransaction())
            {
                entities = session.Query<T>().Select(x => x).Where(expression).ToList();
                tx.Commit();

                return entities;
            }
        }

        public T GetById(Guid id)
        {
            using (var session = DataAccessConfiguration.SessionFactory().OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var entity = session
                                .Query<T>()
                                .Where(x => x.Id == id)
                                .FirstOrDefault();
                tx.Commit();

                return entity;
            }
        }

        public void Remove(T entity)
        {
            using (var session = DataAccessConfiguration.SessionFactory().OpenSession())
            using (var tx = session.BeginTransaction())
            {
                session.Delete(entity);
                tx.Commit();
            }
        }

        public void Remove(IList<T> entities)
        {
            using (var session = DataAccessConfiguration.SessionFactory().OpenSession())
            using (var tx = session.BeginTransaction())
            {
                foreach (var entity in entities)
                {
                    session.Delete(entity);
                }
                tx.Commit();
            }
        }

        public void Update(T entity)
        {
            using (var session = DataAccessConfiguration.SessionFactory().OpenSession())
            using (var trans = session.BeginTransaction())
            {
                session.Update(entity);
                trans.Commit();
            }
        }

        public void Update(IList<T> entities)
        {
            using (var session = DataAccessConfiguration.SessionFactory().OpenSession())
            using (var trans = session.BeginTransaction())
            {
                foreach (var entity in entities)
                {
                    session.Update(entity);
                }
                trans.Commit();
            }
        }
    }
}