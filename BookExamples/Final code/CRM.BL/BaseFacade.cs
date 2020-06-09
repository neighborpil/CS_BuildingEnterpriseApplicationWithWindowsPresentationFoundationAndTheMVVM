using System.ComponentModel.Composition;
using CRM.Dal;
using CRM.Domain.Base;

namespace CRM.BL
{
    public class BaseFacade<TEntity> where TEntity : DomainObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseFacade&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public BaseFacade(TEntity entity)
        {
            Entity = entity;
        }

        /// <summary>
        /// Gets or sets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        [Import]
        public IUnitOfWork UnitOfWork { get; private set; }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>The entity.</value>
        public TEntity Entity { get; private set; }
    }
}