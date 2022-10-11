namespace Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> ReadAll();      
        Task<T?> ReadAsync(int id);
        Task CreateAsync(T item);
        void Update(T item);      
        Task DeleteAsync(int id);
    }
}
