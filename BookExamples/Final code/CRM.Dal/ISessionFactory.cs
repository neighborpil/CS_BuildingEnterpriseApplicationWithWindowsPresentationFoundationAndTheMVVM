namespace CRM.Dal
{
    public interface ISessionFactory
    {
        /// <summary>
        /// Gets the current uo W.
        /// </summary>
        /// <value>The current uo W.</value>
        IUnitOfWork CurrentUoW { get; }
    }
}