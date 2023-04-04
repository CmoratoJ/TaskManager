using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Entities;

namespace TaskManager.Data.DataConfig
{
    public class StatusConfiguration : IEntityTypeConfiguration<EntityStatus>
    {
        public void Configure(EntityTypeBuilder<EntityStatus> builder)
        {
            builder.ToTable("Status");
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Description)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.HasData(
                new EntityStatus(1, "Agendada"),
                new EntityStatus(2, "Em andamento"),
                new EntityStatus(3, "Finalizada")
            );
        }
    }
}
