namespace ManagingSalesOrderData.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> GetByIdAsync(int id);

        public Task<List<TEntity>> GetAllAsync();

        public Task<TEntity> CreateAsync(TEntity entity);

        public Task<TEntity> UpdateAsync(TEntity entity);

        public Task DeleteByIdAsync(int id);
    }
}
