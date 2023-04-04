using Microsoft.EntityFrameworkCore;
using TaskManager.Data.DataContext;
using TaskManager.Repositories.BaseRepository.Interface;

namespace TaskManager.Repositories.BaseRepository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext dataContext;

        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            dataContext.Set<T>().Remove(entity);
            await dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dataContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await dataContext.Set<T>().FindAsync(Id);
        }

        public async Task Insert(T entity)
        {   
            await dataContext.Set<T>().AddAsync(entity);
            await dataContext.SaveChangesAsync();
        }

        public async Task Update(int Id, T entity)
        {
            dataContext.Set<T>().Update(entity);
            await dataContext.SaveChangesAsync();
        }
    }
}
