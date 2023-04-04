using TaskManager.Data.DataContext;
using TaskManager.Entities;
using TaskManager.Repositories.BaseRepository.Repository;
using TaskManager.Repositories.UsersRepository.Interface;

namespace TaskManager.Repositories.UsersRepository.Repository
{
    public class UsersRepository : BaseRepository<EntityUsers>, IUsersRepository
    {
        public UsersRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
