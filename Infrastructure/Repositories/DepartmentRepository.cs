using Infrastructure.Data;
using Infrastructure.Interfaces;
using Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly PersonnelManagementContext _context;

        public DepartmentRepository(PersonnelManagementContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Parameter can't be null");
        }

        public async Task CreateAsync(Department item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Parameter can't be null");
            }

            await _context.Department!.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            Department? department = await ReadAsync(id);
            if (department != null)
            {
                _context.Department!.Remove(department);
            }
        }

        public async Task<Department?> ReadAsync(int id)
        {
            return await _context.Department!.Include(d => d.GroupDepartment).FirstAsync(d => d.Id == id);
        }

        public IEnumerable<Department> ReadAll()
        {
            return _context.Department!;
        }

        public void Update(Department item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Parameter can't be null");
            }

            _context.Department!.Update(item);
        }
    }
}
