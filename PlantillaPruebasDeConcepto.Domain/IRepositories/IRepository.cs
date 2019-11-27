using PlantillaPruebasDeConcepto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlantillaPruebasDeConcepto.Domain.IRepositories
{
    public interface IRepository<E> where E : BaseEntity
    {
        Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>> filter = null,
               Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null,
               string includeProperties = "", bool isTracking = false);

        Task<E> GetById(object id);
        Task<E> AddAsync(E entity);
        Task UpdateAsync(E entity);
        Task DeleteAsync(E entity);
    }
}
