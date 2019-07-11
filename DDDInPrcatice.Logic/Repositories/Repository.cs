using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPrcatice.Logic.Repositories
{
    public abstract class Repository<T> where T:AggregateRoot
    {
        public T GetById(long id)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    return session.Get<T>(id);
                }
            }
        }

        public void Save(T aggregateRoot)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(aggregateRoot);
                    transaction.Commit();
                }
            }
        }
    }
}
