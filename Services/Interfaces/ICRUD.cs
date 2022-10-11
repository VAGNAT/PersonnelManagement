namespace Services.Interfaces
{
    public interface ICRUD<T>
    {
        Task<T?> GetAsync(int id);
        IEnumerable<T> GetAll();
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
    }
}
