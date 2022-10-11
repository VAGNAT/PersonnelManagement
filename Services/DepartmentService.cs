using Infrastructure.Interfaces;
using Model;
using Services.Interfaces;

namespace Services
{
    public class DepartmentService : ICRUD<Department>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork), "Parameter can't be null");
        }

        public async Task CreateAsync(Department item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Parameter can't be null");
            }
            await _unitOfWork.Department.CreateAsync(item);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Department.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Department?> GetAsync(int id)
        {
            return await _unitOfWork.Department.ReadAsync(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return _unitOfWork.Department.ReadAll();
        }

        public async Task UpdateAsync(Department item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Parameter can't be null");
            }

            _unitOfWork.Department.Update(item);
            await _unitOfWork.SaveAsync();
        }
    }
}
