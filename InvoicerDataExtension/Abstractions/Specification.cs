using InvoicerBackendModelsExtension.AbstractTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace InvoicerDataExtension.Abstractions;

public abstract class Specification<T> where T : BaseEntity
{
    public List<Expression<Func<T, object>>> IncludeExpressions { get; private set; } = default!;

    public Expression<Func<T, bool>> PredicateExpressions { get; private set; } = default!;

    public Expression<Func<T, object>> OrderByExpressions { get; private set; } = default!;

    public Expression<Func<T, object>> OrderByDescendingExpressions { get; private set; } = default!;

    public void AddInclude(Expression<Func<T, object>> include)
        => IncludeExpressions.Add(include);

    public void AddOrderBy(Expression<Func<T, object>> orderby)
        => OrderByExpressions = orderby;

    public void AddOrderByDescending(Expression<Func<T, object>> descending)
        => OrderByDescendingExpressions = descending;

    public Specification(Expression<Func<T, bool>>? predicates)
    {
        if (predicates is not null) PredicateExpressions = predicates;
    }
}


public static class SpecificationEvaluator
{
    public static IQueryable<T> GetQuery<T>(
        IQueryable<T> queryable,
        Specification<T> specification) where T : BaseEntity
    {
        queryable = queryable.AsNoTracking().Where(specification.PredicateExpressions);

        var length = 0;

        while (specification.IncludeExpressions.Count > length)
        {
            queryable.Include(specification.IncludeExpressions[length]);
            length++;
        }

        queryable =  specification.OrderByExpressions is not null ? queryable.OrderBy(
            specification.OrderByExpressions) : specification.OrderByDescendingExpressions is not null
            ? queryable.OrderByDescending(specification.OrderByDescendingExpressions) : queryable;

        return queryable;
    }


}
