using Infrastructure.Data;
using Infrastructure.Interfaces;
using Model;

namespace Infrastructure.Repositories
{
    public class PersonnelMovementsRepository : IRepository<PersonnelMovements>
    {
        private readonly PersonnelManagementContext _context;

        public PersonnelMovementsRepository(PersonnelManagementContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Parameter can't be null");
        }

        public async Task CreateAsync(PersonnelMovements item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Parameter can't be null");
            }

            await _context.PersonnelMovements!.AddAsync(item);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonnelMovements?> ReadAsync(int id)
        {
            return await _context.PersonnelMovements!.FindAsync(id);
        }

        public IEnumerable<PersonnelMovements> ReadAll()
        {
            return _context.PersonnelMovements!;
        }

        public void Update(PersonnelMovements item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Parameter can't be null");
            }
            _context.PersonnelMovements!.Update(item);
        }
    }
}
