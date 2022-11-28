using Entity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ClubDbContext _context;
        
        private DbSet<T> table = null;
        

        public GenericRepository(ClubDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
            
        }

        public void Delete(T obj)
        {
            var existing = table.Find(obj);
            table.Remove(existing);
        }

        public  ValueTask<T?> GetByIdAsync(int id)
        {
            
            return  table.FindAsync(id);
        }

        public async void InsertAsync(T obj)
        {
           
           await table.AddAsync(obj);;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async void SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T obj)
        {
            table.Find(obj);
            _context.Entry(obj).State =EntityState.Modified;
        }
    }
}