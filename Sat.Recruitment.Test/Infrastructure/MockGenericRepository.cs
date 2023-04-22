using Sat.Recruitment.Core.Interfaces;
using Sat.Recruitment.Core.Models;
using Sat.Recruitment.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sat.Recruitment.Test.Infrastructure
{
    /// <summary>
    /// A mock implementation of the generic repository interface, where data is stored in memory.
    /// </summary>
    /// <typeparam name="T">The type of entity this repository handles.</typeparam>
    public class MockGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly List<T> _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockGenericRepository{T}"/> class.
        /// </summary>
        /// <param name="data">The initial data to populate this repository with.</param>
        public MockGenericRepository(List<T> data)
        {
            _data = data;
        }

        /// <inheritdoc />
        public IOperationResult<T> Create(T entity)
        {
            _data.Add(entity);
            return BasicOperationResult<T>.Ok(entity);
        }

        /// <inheritdoc />
        public T Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _data.AsQueryable();

            return query.FirstOrDefault(predicate);
        }

        /// <inheritdoc />
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return _data.Where(predicate.Compile());
        }

        /// <inheritdoc />
        public bool Exists(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _data.AsQueryable();

            return query.Any(predicate);
        }

        /// <inheritdoc />
        public void Save()
        {
            // do nothing, this is a mock
        }
    }
}
