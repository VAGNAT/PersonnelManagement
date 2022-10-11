using Infrastructure.Data;
using Infrastructure.Interfaces;
using Model;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonnelManagementContext _context;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<PersonnelMovements> _personnelMovementsRepository;

        public IRepository<Department> Department => _departmentRepository;
        public IRepository<Employee> Employee => _employeeRepository;
        public IRepository<PersonnelMovements> PersonnelMovements => _personnelMovementsRepository;

        public UnitOfWork(PersonnelManagementContext context, IRepository<Department> departmentRepository, IRepository<Employee> employeeRepository, IRepository<PersonnelMovements> personnelMovementsRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Parameter can't be null");
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository), "Parameter can't be null");
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository), "Parameter can't be null");
            _personnelMovementsRepository = personnelMovementsRepository ?? throw new ArgumentNullException(nameof(personnelMovementsRepository), "Parameter can't be null");
        }

        public void Dispose() => _context.Dispose();

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}