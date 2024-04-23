using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfTestJson.Data
{
    internal sealed class PollConfiguration : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.ToTable("Polls");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).HasMaxLength(255).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(1000).IsRequired(false);
            builder.Property(c => c.Start).IsRequired(false);
            builder.Property(c => c.End).IsRequired(false);
            builder.Property(c => c.Status).IsRequired(true);
            builder.OwnsMany(c => c.Categories, d =>
            {
                d.ToJson();
                d.OwnsMany(e => e.Tasks, e =>
                {
                    e.ToJson();
                    e.OwnsMany(f => f.TasksUsers, g =>
                    {
                        g.ToJson();
                        g.Property(f => f.Percent).HasPrecision(18, 2);
                    });
                });
            });
            builder.Property(c => c.CreationDate).IsRequired(false);
            builder.Property(c => c.LastUpdate).IsRequired(false);
            builder.Property(c => c.Version).IsRowVersion();
        }
    }
}
