using ExpertLearning.Domain.LearningContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpertLearning.Infrastructure.DataAccess.Mappings;

public class SubjectMapping : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("subjects");
        
        builder.HasKey(s => s.Id)
            .HasName("subject_pkey");
        
        builder.Property(s => s.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(128)
            .IsRequired();
        
    }
}