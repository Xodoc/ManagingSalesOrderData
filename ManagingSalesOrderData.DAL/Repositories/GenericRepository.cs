using ManagingSalesOrderData.DAL.Database;
using ManagingSalesOrderData.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManagingSalesOrderData.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
