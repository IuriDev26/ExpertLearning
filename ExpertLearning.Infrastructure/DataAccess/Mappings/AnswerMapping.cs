using ExpertLearning.Domain.LearningContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpertLearning.Infrastructure.DataAccess.Mappings;

public class AnswerMapping : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("answers");
        
        builder.HasKey(a => a.Id)
            .HasName("answer_pkey");

        builder.OwnsOne(x => x.AnswerLevel)
            .Property(x => x.Code)
            .HasColumnType("nvarchar")
            .HasColumnName("answer_level")
            .IsRequired();
    }
}