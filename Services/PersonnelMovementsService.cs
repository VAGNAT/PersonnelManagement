using Infrastructure.Interfaces;
using Model;
using Services.Interfaces;

namespace Services
{
    public class PersonnelMovementsService : ICRUD<PersonnelMovements>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonnelMovementsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork), "Parameter can't be null");
        }

        public async Task CreateAsync(PersonnelMovements item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Parameter can't be null");
            }

            await _unitOfWork.PersonnelMovements.CreateAsync(item);
            await _unitOfWork.SaveAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonnelMovements> GetAll()
        {
            return _unitOfWork.PersonnelMovements.ReadAll();
        }

        public Task<PersonnelMovements?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(PersonnelMovements item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Parameter can't be null");
            }

            _unitOfWork.PersonnelMovements.Update(item);
           await _unitOfWork.SaveAsync();
        }
    }
}
