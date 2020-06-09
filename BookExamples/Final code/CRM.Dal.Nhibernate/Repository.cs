﻿using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace CRM.Dal.Nhibernate
{
    public class Repository : IRepository
    {
        public Repository(IUnitOfWork unitOfWork)
        {
            UoW = unitOfWork;
        }

        #region IRepository Members

        /// <summary>
        /// Adds the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public T AddEntity<T>(T entity) where T : class
        {
            this.UoW.Add(entity);
            return entity;
        }

        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public T UpdateEntity<T>(T entity) where T : class
        {
            this.UoW.Update(entity);
            return entity;
        }

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void DeleteEntity<T>(T entity) where T : class
        {
            this.UoW.Delete(entity);
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> GetList<T>() where T : class
        {
            return GetSession().Query<T>();
        }

        public IQueryable<T> GetList<T>(Expression<Func<T, bool>> query) where T : class
        {
            return GetSession().Query<T>().Where(query);
        }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryKey">The primary key.</param>
        /// <returns></returns>
        public T GetEntity<T>(object primaryKey) where T : class
        {
            return GetSession().Get<T>(primaryKey);
        }

        /// <summary>
        /// Gets the uo W.
        /// </summary>
        /// <value>The uo W.</value>
        public IUnitOfWork UoW { get; private set; }

        #endregion

        /// <summary>
        /// Gets the session.
        /// </summary>
        /// <returns></returns>
        private ISession GetSession()
        {
            return (ISession) UoW.Orm;
        }
    }
}