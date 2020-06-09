using System;
using System.ComponentModel.Composition;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace CRM.Dal.Nhibernate
{
    [Export(typeof (ISessionFactory))]
    public class SessionFactory : ISessionFactory
    {
        private IUnitOfWork uow;

        #region ISessionFactory Members

        public IUnitOfWork CurrentUoW
        {
            get
            {
                if (uow == null)
                {
                    uow = GetUnitOfWork();
                }

                return uow;
            }
        }

        #endregion

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <returns></returns>
        private IUnitOfWork GetUnitOfWork()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(Assembly.Load("CRM.Dal.Nhibernate"));
            NHibernate.ISessionFactory factory = cfg.BuildSessionFactory();
            ISession session = factory.OpenSession();
            return new UnitOfWork(session);
        }
    }
}