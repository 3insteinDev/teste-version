using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using teste_version.Entities;

namespace teste_version.Data.Configurations
{
    public class VersionConfiguration : IEntityTypeConfiguration<VersionEntity>
    {
        public void Configure(EntityTypeBuilder<VersionEntity> builder)
        {
            builder.ToTable("Versions");
            builder.HasKey(p => p.Id);
           
        }
    }
}
