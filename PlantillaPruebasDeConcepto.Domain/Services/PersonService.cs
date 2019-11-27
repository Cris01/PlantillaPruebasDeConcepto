using PlantillaPruebasDeConcepto.Domain.Entities;
using PlantillaPruebasDeConcepto.Domain.IRepositories;
using System.Threading.Tasks;

namespace PlantillaPruebasDeConcepto.Domain.Services
{
    public class PersonService
    {
        private readonly IUnitOfWork _UnitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task<string> VerifyIfPersonCanVote(int id) 
        {
            string resultOfVerification = string.Empty;

            var personRepositori = _UnitOfWork.GetRepository<Person>();

            var person = await personRepositori.GetById(id).ConfigureAwait(false);
            if (person.Age>=18)
            {
                resultOfVerification = $"Yes {person.Name} can vote!";
            }
            else 
            {
                resultOfVerification = $"{person.Name} can't vote!";
            }

            return resultOfVerification;
        }
    }
}
