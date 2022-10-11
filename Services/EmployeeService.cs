using Infrastructure.Interfaces;
using Model;
using Services.Interfaces;

namespace Services
{
    public class EmployeeService : ICRUD<Employee>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork), "Parameter can't be null");
        }

        public async Task CreateAsync(Employee item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Parameter can't be null");
            }

            await _unitOfWork.Employee.CreateAsync(item);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Employee.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Employee?> GetAsync(int id)
        {
            return await _unitOfWork.Employee.ReadAsync(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _unitOfWork.Employee.ReadAll();
        }

        public async Task UpdateAsync(Employee item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Parameter can't be null");
            }

            _unitOfWork.Employee.Update(item);
            await _unitOfWork.SaveAsync();
        }
    }
}
