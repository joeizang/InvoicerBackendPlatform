using InvoicerBackendModelsExtension.AbstractTypes;
using InvoicerDataExtension.Abstractions;
using InvoicerDataExtension.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace InvoicerDataExtension.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly InvoicerPlatformContext _db;

    private DbSet<T> _set;

    public GenericRepository(InvoicerPlatformContext db)
    {
        _db = db;
        _set = _db.Set<T>();
    }
    public async Task<T> CreateOne(T entity)
    {
        _set.Add(entity);
        await _db.SaveChangesAsync().ConfigureAwait(false);
        var result = await _set.SingleOrDefaultAsync(x => x.Id == entity.Id).ConfigureAwait(false);
        return result;
    }

    public async Task<T> DeleteOne(T entity)
    {
        _db.Entry<T>(entity).State = EntityState.Modified;
        await _db.SaveChangesAsync().ConfigureAwait(false);
        return entity;
    }

    public async Task<T> EditOne(T entity)
    {
        _db.Entry<T>(entity).State = EntityState.Modified;
        await _db.SaveChangesAsync().ConfigureAwait(false);
        return entity;
    }

    public async Task<IEnumerable<T>> GetMany(Specification<T> specification)
    {
        var query = ApplySpecification(specification);

        var massagedResult = await query
                        .ToArrayAsync().ConfigureAwait(false);
        return massagedResult;
    }

    public async Task<T> GetOneById(Specification<T> spec)
    {
        var query = ApplySpecification(spec);
        var result = await query
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);
        return result;
    }

    public async Task<T> GetOneByPredicates(Specification<T> spec)
    {
        var query = ApplySpecification(spec)
                    .IgnoreQueryFilters();
        var massagedResult = await query
                    .FirstOrDefaultAsync().ConfigureAwait(false);
        return massagedResult;
    }

    private IQueryable<T> ApplySpecification(Specification<T> spec)
    {
        return SpecificationEvaluator.GetQuery(_set, spec);
    }
}
