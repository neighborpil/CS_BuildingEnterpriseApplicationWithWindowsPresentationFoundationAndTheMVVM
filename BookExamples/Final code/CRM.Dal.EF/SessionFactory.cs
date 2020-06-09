using System.ComponentModel.Composition;
using System.Configuration;

namespace CRM.Dal.EF
{
    [Export(typeof (ISessionFactory))]
    public class SessionFactory : ISessionFactory
    {
        private IUnitOfWork uow;

        #region ISessionFactory Members

        /// <summary>
        /// Gets the current uo W.
        /// </summary>
        /// <value>The current uo W.</value>
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
            var orm = new CrmObjectContext();
            return new UnitOfWork(orm);
        }
    }
}