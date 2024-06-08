using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Infrastructure.Database.Configuration;

internal sealed class SectionConfiguration : IEntityTypeConfiguration<Section.Domain.Models.Section>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Section> builder)
    {
        builder.ToTable("sections");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(60);

        builder.Property(s => s.Description)
            .IsRequired()
            .HasMaxLength(254);

        builder.Property(s => s.IsSport)
            .IsRequired();

        builder.Property(s => s.Day)
            .IsRequired();

        builder.Property(s => s.Time)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => TimeOnly.Parse(v)
            );

        builder.Property(s => s.LimitOfPlaces)
            .IsRequired();

        builder.Property(s => s.CreateDate)
            .IsRequired();



    }
}
