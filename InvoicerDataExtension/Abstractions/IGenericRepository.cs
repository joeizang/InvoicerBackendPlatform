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
    Task<IEnumerable<T>> GetMany(Specification<T> spec);

    Task<T> GetOneById(Specification<T> spec);

    Task<T> GetOneByPredicates(Specification<T> spec);

    Task<T> CreateOne(T entity);

    Task<T> EditOne(T entity);

    Task<T> DeleteOne(T entity);
}