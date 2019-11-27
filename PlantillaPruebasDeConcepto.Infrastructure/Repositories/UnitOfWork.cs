using PlantillaPruebasDeConcepto.Domain.Entities;
using PlantillaPruebasDeConcepto.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantillaPruebasDeConcepto.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly MyOwnContext _AppContext;
        private readonly Dictionary<string, object> _Dictionary;

        public UnitOfWork(MyOwnContext context)
        {
            _AppContext = context;
            _Dictionary = new Dictionary<string, object>();
        }


        public IRepository<T> GetRepository<T>() where T : EntityBase
        {
            var key = typeof(T).Name;

            if (!_Dictionary.ContainsKey(key))
            {
                var repositoryType = typeof(Repository<T>);
                var repositoryInstance = Activator
                    .CreateInstance(repositoryType, _AppContext);
                _Dictionary.Add(key, repositoryInstance);
            }

            return (IRepository<T>)_Dictionary[key];

        }


        public async Task<int> Commit()
        {
            _AppContext.ChangeTracker.DetectChanges();
            return await _AppContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}

