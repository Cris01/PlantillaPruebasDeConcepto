using Microsoft.EntityFrameworkCore;
using PlantillaPruebasDeConcepto.Domain.Entities;
using PlantillaPruebasDeConcepto.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlantillaPruebasDeConcepto.Infrastructure.Repositories
{
    public class Repository<E> : IRepository<E> where E : EntityBase
    {
        private readonly MyOwnContext _Context;
        private readonly DbSet<E> _Set;

        public Repository(MyOwnContext context)
        {
            _Context = context;
            _Set = _Context.Set<E>();
        }

        public async Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>> filter = null,
            Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null,
            string includeProperties = "", bool isTracking = false)
        {
            IQueryable<E> query = _Set as IQueryable<E>;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
            (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync().ConfigureAwait(false);
            }

            return (!isTracking) ? await query.AsNoTracking().ToListAsync().ConfigureAwait(false)
                : await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<E> GetById(object id)
        {
            return await _Set.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<E> AddAsync(E entity)
        {
            if (entity != null)
            {
                await _Set.AddAsync(entity).ConfigureAwait(false);
            }
            return entity;
        }

        public async Task UpdateAsync(E entity)
        {
            if (entity != null)
            {
                await Task.Run(() => _Set.Update(entity)).ConfigureAwait(false);
                _Context.SaveChanges();
            }
        }

        public async Task DeleteAsync(E entity)
        {
            if (entity != null)
            {
                await Task.Run(() => _Set.Remove(entity)).ConfigureAwait(false);
            }
        }
    }
}
