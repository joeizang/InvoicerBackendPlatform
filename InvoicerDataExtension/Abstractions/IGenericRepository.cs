using InvoicerBackendModelsExtension.AbstractTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerDataExtension.Abstractions;

public interface IGenericRepository<T> where T : IBaseEntity
{
    Task<IEnumerable<U>> GetMany<U>(Expression<Func<T, object>>[]? includes, params Func<T, bool>[]? predicates) where U : class;

    Task<U> GetOneById<U>(Guid id) where U : class;

    Task<U> GetOneByPredicates<U>(Expression<Func<T, object>>[]? includes, params Func<T, bool>[] predicate) where U : class;

    Task<U> CreateOne<U>(T entity) where U : class;

    Task<U> EditOne<U>(T entity) where U : class;

    Task<U> DeleteOne<U>(T entity) where U : class;
}


public struct SearchParams<T>
{
    public static IList<Expression<Func<T, object>>> SearchExpressions { get; set; } = default!;

    public static IList<Expression<Func<T, bool>>> PredicateExpressions { get; set; } = default!;
}