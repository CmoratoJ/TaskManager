using TaskManager.Entities;
using TaskManager.Repositories.BaseRepository.Interface;

namespace TaskManager.Repositories.TasksRepository.Interface
{
    public interface ITasksRepository : IBaseRepository<EntityTasks>
    {
    }
}
