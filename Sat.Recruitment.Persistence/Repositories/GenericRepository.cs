using CsvHelper;
using CsvHelper.Configuration;
using Sat.Recruitment.Core.Interfaces;
using Sat.Recruitment.Core.Models;
using Sat.Recruitment.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Sat.Recruitment.Persistence.Repositories
{
    /// <summary>
    /// Represents a generic repository that stores entities in a CSV file.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CsvConfiguration _csvConfiguration;
        private readonly string _fullPath;
        private List<T> _entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="fileConfiguration">The configuration for the CSV file.</param>
        public GenericRepository(FileConfiguration fileConfiguration)
        {
            _fullPath = $"{Directory.GetCurrentDirectory()}{fileConfiguration.Path}";
            _csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ",",
                MissingFieldFound = null
            };
        }

        /// <inheritdoc/>
        public IOperationResult<T> Create(T entity)
        {
            _entities = ReadCsvFile();
            _entities.Add(entity);

            return BasicOperationResult<T>.Ok(entity);
        }

        /// <inheritdoc/>
        public T Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            _entities = ReadCsvFile();
            return _entities.AsQueryable().Where(predicate).FirstOrDefault();
        }

        /// <inheritdoc/>
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            _entities = ReadCsvFile();
            return _entities.AsQueryable().Where(predicate).ToList();
        }

        /// <inheritdoc/>
        public bool Exists(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            _entities = ReadCsvFile();
            return _entities.AsQueryable().Any(predicate);
        }

        /// <inheritdoc/>
        public void Save()
        {
            using var writer = new StreamWriter(_fullPath);
            using var csv = new CsvWriter(writer, _csvConfiguration);
            csv.WriteRecords(_entities);
        }

        private List<T> ReadCsvFile()
        {
            using var reader = new StreamReader(_fullPath);
            using var csv = new CsvReader(reader, _csvConfiguration);
            return csv.GetRecords<T>().ToList();
        }
    }
}
