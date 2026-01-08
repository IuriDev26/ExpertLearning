using ExpertLearning.Domain.LearningContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpertLearning.Infrastructure.DataAccess.Mappings;

public class FlashcardMapping : IEntityTypeConfiguration<Flashcard>
{
    public void Configure(EntityTypeBuilder<Flashcard> builder)
    {
        builder.ToTable("flashcards");
        
        builder
            .HasKey(x => x.Id)
            .HasName("flashcard_pkey");

        builder.OwnsOne(x => x.Answer)
            .Property(x => x.Content)
            .HasColumnName("answer_content")
            .HasColumnType("nvarchar")
            .IsRequired();
        
        builder.OwnsOne(x => x.Question)
            .Property(x => x.Content)
            .HasColumnName("question_content")
            .HasColumnType("nvarchar")
            .IsRequired();

        builder.HasMany(flashcard => flashcard.AnswerHistory)
            .WithOne()
            .HasForeignKey(answer => answer.FlashcardId)
            .HasConstraintName("answer_flashcard_id_fkey");
        
        builder.Metadata
            .FindNavigation(nameof(Flashcard.AnswerHistory))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

    }
}