using Model;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Department> Department { get; }
        IRepository<Employee> Employee { get; }
        IRepository<PersonnelMovements> PersonnelMovements { get; }
        void Dispose();
        Task SaveAsync();
    }
}
