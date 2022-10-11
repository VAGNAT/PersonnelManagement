using Infrastructure.Data;
using Infrastructure.Interfaces;
using Model;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly PersonnelManagementContext _context;

        public EmployeeRepository(PersonnelManagementContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Parameter can't be null");
        }

        public async Task CreateAsync(Employee item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Parameter can't be null");
            }

            await _context.Employee!.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            Employee? employee = await ReadAsync(id);
            if (employee != null)
            {
                _context.Employee!.Remove(employee);
            }
        }

        public async Task<Employee?> ReadAsync(int id)
        {
            return await _context.Employee!.FindAsync(id);
        }

        public IEnumerable<Employee> ReadAll()
        {
            return _context.Employee!;
        }

        public void Update(Employee item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Parameter can't be null");
            }
            _context.Employee!.Update(item);
        }
    }
}
