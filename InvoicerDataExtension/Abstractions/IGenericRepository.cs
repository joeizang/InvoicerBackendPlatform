using InvoicerBackendModelsExtension.AbstractTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerDataExtension.Abstractions;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<U>> GetMany<U>(Specification<T> spec) where U : class;

    Task<U> GetOneById<U>(Specification<T> spec) where U : class;

    Task<U> GetOneByPredicates<U>(Specification<T> spec) where U : class;

    Task<U> CreateOne<U>(T entity) where U : class;

    Task<U> EditOne<U>(T entity) where U : class;

    Task<U> DeleteOne<U>(T entity) where U : class;
}