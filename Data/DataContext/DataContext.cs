using Microsoft.EntityFrameworkCore;
using TaskManager.Data.DataConfig;
using TaskManager.Entities;

namespace TaskManager.Data.DataContext
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EntityTasks>(new TasksConfiguration().Configure);
            builder.Entity<EntityUsers>(new UsersConfiguration().Configure);
            builder.Entity<EntityStatus>(new StatusConfiguration().Configure);
            base.OnModelCreating(builder);
        }
    }
}
