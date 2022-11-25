namespace Entity.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetByIdAsync(int id);

    }
}