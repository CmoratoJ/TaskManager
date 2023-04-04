using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Entities;

namespace TaskManager.Data.DataConfig
{
    public class UsersConfiguration : IEntityTypeConfiguration<EntityUsers>
    {
        public void Configure(EntityTypeBuilder<EntityUsers> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

        }
    }
}
