using PlantillaPruebasDeConcepto.Domain.Entities;
using System.Threading.Tasks;

namespace PlantillaPruebasDeConcepto.Domain.IRepositories
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
        IRepository<T> GetRepository<T>() where T : EntityBase;
    }
}