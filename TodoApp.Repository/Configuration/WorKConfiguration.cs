using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Core.Model;

namespace TodoApp.Repository.Configuration
{
    public class WorKConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Definition).IsRequired().HasMaxLength(200);
            builder.Property(x => x.IsCompleted).IsRequired();
        }
    }
}
