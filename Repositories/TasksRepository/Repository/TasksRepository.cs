using TaskManager.Data.DataContext;
using TaskManager.Entities;
using TaskManager.Repositories.BaseRepository.Repository;
using TaskManager.Repositories.TasksRepository.Interface;

namespace TaskManager.Repositories.TasksRepository.Repository
{
    public class TasksRepository : BaseRepository<EntityTasks>, ITasksRepository
    {
        public TasksRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
