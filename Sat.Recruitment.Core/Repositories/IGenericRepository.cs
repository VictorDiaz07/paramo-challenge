using Sat.Recruitment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sat.Recruitment.Core.Repositories
{
    /// <summary>
    /// Represents the basic operations that can be performed over a repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// Stores a given <see cref="T"/>
        /// </summary>
        /// <param name="entity">An instance of <see cref="T"/></param>
        /// <returns>An implementation of <see cref="IOperationResult<T>"/></returns>
        IOperationResult<T> Create(T entity);

        /// <summary>
        /// Gets an instance of <see cref="T"/> according with the given expression parameter.
        /// </summary>
        /// <param name="predicate">Contains the filter that will be used for the search in the database.</param>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>An instance of <see cref="T"/>.</returns>
        T Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Gets a collection of <see cref="T"/> according with the given expression parameter.
        /// </summary>
        /// <param name="predicate">Contains the filter that will be used for the search in the database.</param>
        /// <returns>An <see cref="IEnumerable{T}"/>.</returns>
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Checks the existence of any <see cref="T"/> that match the filter parameter.
        /// </summary>
        /// <param name="predicate">Contains the filter that will be used for the search in the database.</param>
        /// <param name="includes">Contains all entities related to the <see cref="T"/> that are to be included in the query.</param>
        /// <returns>A <see cref="bool"/> value representing if <see cref="T"/> exists</returns>
        bool Exists(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Performs the saving of the changes that have been executed on <see cref="T"/>.
        /// </summary>
        void Save();
    }
}
