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
            try
            {
                _set.Add(entity);
                await _db.SaveChangesAsync().ConfigureAwait(false);
                var result = await _set.SingleOrDefaultAsync(x => x.Id == entity.Id).ConfigureAwait(false);
                return result?.Adapt<U>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<U> DeleteOne<U>(T entity) where U : class
        {
            try
            {
                _db.Entry<T>(entity).State = EntityState.Modified;
                await _db.SaveChangesAsync().ConfigureAwait(false);
                return entity.Adapt<U>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<U> EditOne<U>(T entity) where U : class
        {
            try
            {
                _db.Entry<T>(entity).State = EntityState.Modified;
                await _db.SaveChangesAsync().ConfigureAwait(false);
                return entity.Adapt<U>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<U>> GetMany<U>(Expression<Func<T, object>>[]? includes, Func<T, bool>[]? predicates) where U : class
        {
            var query = _set.AsNoTracking()
                            .IgnoreQueryFilters();
            if (includes is null && predicates is null)
            {
                var result = await query.OrderBy(x => x.CreatedAt)
                            .ProjectToType<U>()
                            .ToArrayAsync().ConfigureAwait(false);
                return result;
            }
            var localFunction = () =>
            {
                var length = 0;

                while (includes?.Length > length)
                {
                    query.Include(includes[length]);
                    length++;
                }
                foreach (var p in predicates)
                {
                    query.Where(p);
                }
            };
            localFunction();
            var massagedResult = await query
                            .OrderBy(x => x.CreatedAt)
                            .ProjectToType<U>()
                            .ToArrayAsync().ConfigureAwait(false);
            return massagedResult;
        }

        public async Task<U> GetOneById<U>(Guid id) where U : class
        {
            try
            {
                var result = await _set.AsNoTracking()
                        .SingleOrDefaultAsync(x => x.Id.Equals(id))
                        .ConfigureAwait(false);
                return result is not null ? result.Adapt<U>() : result.Adapt<U>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<U> GetOneByPredicates<U>(Expression<Func<T, object>>[]? includes, params Func<T, bool>[] predicates) where U : class
        {
            try
            {
                var query = _set.AsNoTracking()
                            .IgnoreQueryFilters();
                if (includes is null && predicates is null)
                {
                    var result = await query.OrderBy(x => x.CreatedAt)
                                .ProjectToType<U>()
                                .FirstOrDefaultAsync().ConfigureAwait(false);
                    return result;
                }
                var localFunction = () =>
                {
                    var length = 0;

                    while (includes?.Length > length)
                    {
                        query.Include(includes[length]);
                        length++;
                    }
                    foreach (var p in predicates)
                    {
                        query.Where(p);
                    }
                };
                localFunction();
                var massagedResult = await query
                            .OrderBy(x => x.CreatedAt)
                            .ProjectToType<U>()
                            .FirstOrDefaultAsync().ConfigureAwait(false);
                return massagedResult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
