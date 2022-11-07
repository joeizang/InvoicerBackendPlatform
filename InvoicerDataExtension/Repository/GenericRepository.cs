using InvoicerBackendModelsExtension.AbstractTypes;
using InvoicerBackendModelsExtension.DTOs;
using InvoicerBackendModelsExtension.Responses;
using InvoicerDataExtension.Abstractions;
using InvoicerDataExtension.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerDataExtension.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly InvoicerPlatformContext _db;

        private DbSet<T> _set;

        public GenericRepository(InvoicerPlatformContext db)
        {
            _db = db;
            _set = _db.Set<T>();
        }
        public async Task<U> CreateOne<U>(T entity) where U : class
        {
            _set.Add(entity);
            await _db.SaveChangesAsync().ConfigureAwait(false);
            var result = await _set.SingleOrDefaultAsync(x => x.Id == entity.Id).ConfigureAwait(false);
            return result?.Adapt<U>();
        }

        public async Task<U> DeleteOne<U>(T entity) where U : class
        {
            _db.Entry<T>(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync().ConfigureAwait(false);
            return entity.Adapt<U>();
        }

        public async Task<U> EditOne<U>(T entity) where U : class
        {
            _db.Entry<T>(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync().ConfigureAwait(false);
            return entity.Adapt<U>();
        }

        public async Task<IEnumerable<U>> GetMany<U>(Specification<T> specification) where U : class
        {
            var query = ApplySpecification(specification);

            var massagedResult = await query
                            .ProjectToType<U>()
                            .ToArrayAsync().ConfigureAwait(false);
            return massagedResult;
        }

        public async Task<U> GetOneById<U>(Specification<T> spec) where U : class
        {
            var query = ApplySpecification(spec);
            var result = await query
                    .SingleOrDefaultAsync()
                    .ConfigureAwait(false);
            return result is not null ? result.Adapt<U>() : result.Adapt<U>();
        }

        public async Task<U> GetOneByPredicates<U>(Specification<T> spec) where U : class
        {
            var query = ApplySpecification(spec)
                        .IgnoreQueryFilters();
            var massagedResult = await query
                        .ProjectToType<U>()
                        .FirstOrDefaultAsync().ConfigureAwait(false);
            return massagedResult;
        }

        private IQueryable<T> ApplySpecification(Specification<T> spec)
        {
            return SpecificationEvaluator.GetQuery(_set, spec);
        }
    }
}
