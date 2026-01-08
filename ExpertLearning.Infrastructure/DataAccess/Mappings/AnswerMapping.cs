using ExpertLearning.Domain.LearningContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpertLearning.Infrastructure.DataAccess.Mappings;

public class AnswerMapping : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("answers");
        
        builder.Property( x => x.FlashcardId)
            .HasColumnName("flashcard_id")
            .HasColumnType("int")
            .IsRequired();
        
        builder.OwnsOne(x => x.AnswerLevel)
            .Property(x => x.Code)
            .HasColumnType("varchar")
            .HasMaxLength(128)
            .HasColumnName("answer_level")
            .IsRequired();
    }
}