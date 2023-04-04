using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Entities;

namespace TaskManager.Data.DataConfig
{
    public class TasksConfiguration : IEntityTypeConfiguration<EntityTasks>
    {
        public void Configure(EntityTypeBuilder<EntityTasks> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.DateScheduleInitial)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.DateScheduleFinal)
                .HasColumnType("datetime");

            builder.Property(p => p.Description)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.ServiceTime)
                .HasColumnType("varchar(100)");
        }
    }
}
