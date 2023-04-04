using TaskManager.Data.DataContext;
using TaskManager.Entities;
using TaskManager.Repositories.BaseRepository.Repository;
using TaskManager.Repositories.StatusRepository.Interface;

namespace TaskManager.Repositories.StatusRepository.Repository
{
    public class StatusRepository : BaseRepository<EntityStatus>, IStatusRepository
    {
        public StatusRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
